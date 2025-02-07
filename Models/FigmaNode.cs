using Newtonsoft.Json;

namespace FigmaPareNet.Models
{
    public class FigmaNode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public string MainComponent { get; set; }
        public string ComponentSet { get; set; }
        public Dictionary<string, FigmaComponentProperty>? ComponentProperties { get; set; }
        public Dictionary<string, string> Style { get; set; }
        public bool IsAutoLayout { get; set; }
        public List<FigmaNode> Children { get; set; }
        public string? PreviewImageUrl { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, formatting: Formatting.Indented);
        }
    }
}
