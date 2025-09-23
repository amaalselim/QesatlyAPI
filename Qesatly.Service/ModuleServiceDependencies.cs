using Microsoft.Extensions.DependencyInjection;
using Qesatly.Service.Abstracts;
using Qesatly.Service.Implementation;
using Qesatly.Service.Mapping;

namespace Qesatly.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IImageService, ImageService>();


            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });


            return services;
        }
    }
}
