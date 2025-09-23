using Microsoft.Extensions.DependencyInjection;
using Qesatly.Infrastructure.Abstracts;
using Qesatly.Infrastructure.Repositories;

namespace Qesatly.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IContractRepository, ContractRepository>();
            return services;
        }
    }
}
