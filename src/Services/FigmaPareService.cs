using FigmaPareNet.Client;
using FigmaPareNet.Consts;
using FigmaPareNet.Models;
using Newtonsoft.Json;

namespace FigmaPareNet.Services
{
    public class FigmaPareService : IFigmaPareService
    {
        private readonly IFigmaClient _figmaClient;

        public FigmaPareService(IFigmaClient figmaClient)
        {
            _figmaClient = figmaClient;
        }

        public async Task<string> GetFigmaNodeDesignJson(FigmaNodeQuery input)
        {
            var normalizedNodeId = NormalizeNodeId(input.NodeId);
            var figmaJson = await _figmaClient.GetFigmaNode(input.FileKey, normalizedNodeId);

            if (string.IsNullOrEmpty(figmaJson))
            {
                return null;
            }

            var figmaResponse = JsonConvert.DeserializeObject<FigmaNodeResponse>(figmaJson);
            if (figmaResponse == null || figmaResponse.Nodes == null)
            {
                return null;
            }
            var node = figmaResponse.Nodes.FirstOrDefault(n => n.Key == normalizedNodeId).Value;
            var figmaNode = await NodeConvert(input.FileKey, node.Document, node.Components, node.ComponentSets, node.Styles);

            return figmaNode.ToJson();
        }

        private string NormalizeNodeId(string nodeId)
        {
            return nodeId.Replace("-", ":").Trim();
        }

        private async Task<FigmaNode> NodeConvert(string fileKey,
            FigmaNodeDocument document,
            Dictionary<string, FigmaNodeComponent> components,
            Dictionary<string, FigmaNodeComponentSet> componentSets,
            Dictionary<string, FigmaNodeStyles>? styles)
        {
            var figmaNode = CreateBaseFigmaNode(document, styles);

            await ProcessComponentProperties(fileKey, document, components, componentSets, figmaNode);
            await ProcessChildren(fileKey, document, components, componentSets, styles, figmaNode);
            return figmaNode;
        }

        private FigmaNode CreateBaseFigmaNode(FigmaNodeDocument document, Dictionary<string, FigmaNodeStyles>? styles)
        {
            return new FigmaNode
            {
                Id = document.Id,
                Name = document.Name,
                Type = document.Type,
                Text = GetNodeText(document),
                ComponentProperties = document.ComponentProperties,
                Style = StyleConverter.ConvertFigmaStyleToCSS(document, styles),
                IsAutoLayout = document.LayoutMode != null,
                Children = new List<FigmaNode>(),
            };
        }

        private string GetNodeText(FigmaNodeDocument document)
        {
            return document.Type == FigmaNodeConsts.FigmaTextType ? document.Characters ?? "" : "";
        }

        private async Task ProcessChildren(string fileKey,
           FigmaNodeDocument document,
           Dictionary<string, FigmaNodeComponent> components,
           Dictionary<string, FigmaNodeComponentSet> componentSets,
           Dictionary<string, FigmaNodeStyles>? styles,
           FigmaNode figmaNode)
        {
            if (document.Children == null) return;

            foreach (var child in document.Children.Where(c => c != null && c.Visible != false))
            {
                var childNode = await NodeConvert(fileKey, child, components, componentSets, styles);
                figmaNode.Children.Add(childNode);
            }
        }

        private async Task ProcessComponentProperties(string fileId, FigmaNodeDocument document,
            Dictionary<string, FigmaNodeComponent> components,
            Dictionary<string, FigmaNodeComponentSet> componentSets,
            FigmaNode figmaNode)
        {
            if (IsComponentOrInstance(document.Type))
            {
                if (string.IsNullOrEmpty(document.ComponentId) ||
                 !components.ContainsKey(document.ComponentId))
                {
                    return;
                }

                var component = components[document.ComponentId];
                figmaNode.MainComponent = component.Name;

                if (!string.IsNullOrEmpty(component.ComponentSetId) &&
                    componentSets?.ContainsKey(component.ComponentSetId) == true)
                {
                    figmaNode.ComponentSet = componentSets[component.ComponentSetId].Name;
                }
            }
        }

        private bool IsComponentOrInstance(string nodeType)
        {
            return nodeType == FigmaNodeConsts.FigmaInstanceType ||
                   nodeType == FigmaNodeConsts.FigmaComponentType;
        }

    }
}
