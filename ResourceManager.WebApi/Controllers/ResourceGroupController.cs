using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResourceManager.WebApi.Azure;

namespace ResourceManager.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResourceGroupController
    {
        private readonly ILogger<ResourceGroupController> logger;
        private readonly AzureTokenService service;
        
        public ResourceGroupController(AzureTokenService service, ILogger<ResourceGroupController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return await this.service.Get();
        }
    }
}