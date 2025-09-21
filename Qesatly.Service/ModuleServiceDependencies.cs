using Microsoft.Extensions.DependencyInjection;
using Qesatly.Service.Abstracts;
using Qesatly.Service.Implementation;

namespace Qesatly.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
    }
}
