using Microsoft.Extensions.DependencyInjection;
using Qesatly.Core.Bases;

namespace Qesatly.Core
{
    public static class ModuleCoreDependecies
    {
        public static IServiceCollection AddCoreDependecies(this IServiceCollection services)
        {
            services.AddTransient<ResponseHandler>();
            return services;
        }
    }
}
