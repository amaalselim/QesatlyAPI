using Microsoft.Extensions.DependencyInjection;
using Qesatly.Infrastructure.Abstracts;
using Qesatly.Infrastructure.Repositories;

namespace Qesatly.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IInstallmentRepository, InstallmentRepository>();
            return services;
        }
    }
}
