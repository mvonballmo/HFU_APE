using Microsoft.Extensions.DependencyInjection;
using MLZ2025.Core.Model;
using MLZ2025.Core.Services;
using MLZ2025.Shared.Model;

namespace MLZ2025.Shared.Services
{
    public static class SharedServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<DataAccess<DatabaseAddress>>()
                .AddSingleton<DataAccessSettings>()
                .AddTransient<IHttpServerAccess, HttpServerAccess>()
                .AddTransient<HttpClient>();
        }
    }
}
