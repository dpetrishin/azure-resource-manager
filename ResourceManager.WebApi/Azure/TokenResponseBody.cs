using Newtonsoft.Json;

namespace ResourceManager.WebApi.Azure
{
    public class TokenResponseBody
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}