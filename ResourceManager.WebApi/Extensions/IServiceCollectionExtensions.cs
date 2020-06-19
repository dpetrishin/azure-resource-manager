using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceManager.WebApi.Configuration;

namespace ResourceManager.WebApi.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new AppSettings();
            configuration.Bind(settings);
            services.AddSingleton(settings);
        }
    }
}