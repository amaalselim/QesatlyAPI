using Microsoft.OpenApi.Models;
using Qesatly.Core;
using Qesatly.Service;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace QesatlyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                {
                    builder
                        .SetIsOriginAllowed(_ => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            #region Dependency Injection

            builder.Services.AddServiceDependencies()
                .AddCoreDependecies();
            #endregion

            #region SwaggerRegion
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Skilly API", Version = "v1" });
                c.CustomSchemaIds(type => type.FullName);
                c.SchemaGeneratorOptions = new SchemaGeneratorOptions
                {
                    UseAllOfToExtendReferenceSchemas = false
                };
                // Add support for bearer token authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter 'Bearer' followed by a space and the token.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
            new string[] {}
        }
                });
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
