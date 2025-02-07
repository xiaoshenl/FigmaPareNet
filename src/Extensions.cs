using FigmaPareNet.Client;
using FigmaPareNet.Config;
using FigmaPareNet.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FigmaPareNet
{
    public static class Extensions
    {
        public static IServiceCollection AddFigmaPareNet(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FigmaConfig>(configuration.GetSection("Figma"));
            var config = configuration.GetSection("Figma").Get<FigmaConfig>();

            if (config == null)
            {
                throw new Exception("Figma configuration is missing");
            }

            services.AddScoped<IFigmaClient, FigmaClient>();
            services.AddScoped<IFigmaPareService, FigmaPareService>();

            return services;
        }
    }
}
