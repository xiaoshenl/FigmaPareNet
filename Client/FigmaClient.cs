using FigmaPareNet.Config;
using FigmaPareNet.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FigmaPareNet.Client
{
    public class FigmaClient : IFigmaClient
    {
        private readonly HttpClient _httpClient;
        public FigmaClient(IHttpClientFactory httpClientFactory, IOptions<FigmaConfig> options)
        {
            _httpClient = httpClientFactory.CreateClient("Figma");
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-FIGMA-TOKEN", options.Value.Token);
        }

        public async Task<string> GetFigmaNode(string fileKey, string nodeId)
        {
            var url = $"v1/files/{fileKey}/nodes?ids={nodeId}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<string> GetFigmaNodeImage(string fileKey, string nodeId, string format)
        {
            var escapedNodeId = Uri.EscapeDataString(nodeId);
            var url = $"v1/images/{fileKey}?ids={escapedNodeId}&format={format}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var figmaImageResponse = JsonConvert.DeserializeObject<FigmaImageResponse>(content);
            return figmaImageResponse.Images.FirstOrDefault().Value;
        }
    }
}
