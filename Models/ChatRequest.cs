using System.Text.Json.Serialization;

namespace ChatDemoMVC.Models
{
    public class ChatRequest
    {
        
        [JsonPropertyName("prompt")]
        public string? Prompt
        {
            get;
            set;
        }
        [JsonPropertyName("model")]
        public string? Model
        {
            get;
            set;
        }
        [JsonPropertyName("max_tokens")]
        public int? MaxTokens
        {
            get;
            set;
        }
    }
}
