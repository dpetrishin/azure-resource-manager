using System.Threading.Tasks;

namespace ResourceManager.WebApi.Azure
{
    public interface IAzureTokenService
    {
        Task<string> Get();

        Task<string> Refresh();
    }
}