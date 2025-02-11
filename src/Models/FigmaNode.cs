using Newtonsoft.Json;

namespace FigmaPareNet.Models
{
    public class FigmaNode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Text { get; set; }
        public string? MainComponent { get; set; }
        public string? ComponentSet { get; set; }
        public bool IsAutoLayout { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, FigmaComponentProperty>? ComponentProperties { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string>? Style { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<FigmaNode>? Children { get; set; }

        public string ToJson()
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(this, settings);
        }
    }
}
