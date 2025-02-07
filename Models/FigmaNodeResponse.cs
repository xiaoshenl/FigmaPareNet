namespace FigmaPareNet.Models
{
    public class FigmaNodeResponse
    {
        public string? Name { get; set; }
        public Dictionary<string, FigmaNodeData>? Nodes { get; set; }
    }
    public class FigmaNodeData
    {
        public FigmaNodeDocument? Document { get; set; }
        public Dictionary<string, FigmaNodeComponent>? Components { get; set; }
        public Dictionary<string, FigmaNodeComponentSet>? ComponentSets { get; set; }
        public Dictionary<string, FigmaNodeStyles>? Styles { get; set; }
    }

    public class FigmaNodeComponent
    {
        public string? Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ComponentSetId { get; set; }
        public List<object>? DocumentationLinks { get; set; }
    }

    public class FigmaNodeComponentSet
    {
        public string? Key { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class FigmaNodeStyles
    {
        public string? Key { get; set; }
        public string? Name { get; set; }
        public string? StyleType { get; set; }
        public string? Description { get; set; }
    }
}
