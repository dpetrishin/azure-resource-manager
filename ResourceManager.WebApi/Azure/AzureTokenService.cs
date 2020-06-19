using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ResourceManager.WebApi.Configuration;

namespace ResourceManager.WebApi.Azure
{
    public class AzureTokenService //: IAzureTokenService
    {
        private readonly HttpClient client;
        private readonly AppSettings settings;
        private readonly ILogger<AzureTokenService> logger;
        
        public AzureTokenService(HttpClient client, AppSettings settings, ILogger<AzureTokenService> logger)
        {
            this.client = client;
            this.settings = settings;
            this.logger = logger;
        }

        public async Task<string> Get()
        {
            var model = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", this.settings.ClientId },
                { "client_secret", this.settings.ClientSecret },
                { "resource", "https://graph.microsoft.com/" }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://login.microsoftonline.com/5be72dd3-afd3-42c5-8a26-0d35572ff526/oauth2/token")
            {
                Content = new FormUrlEncodedContent(model)
            };

            var response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
            // var responseModel = JsonConvert.DeserializeObject<TokenResponseBody>(content);
            //
            // return responseModel.AccessToken;
        }

        public async Task<string> Refresh()
        {
            throw new System.NotImplementedException();
        }
    }
}