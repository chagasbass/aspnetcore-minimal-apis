using MinimalApi.ApplicationServices.Contracts;
using MinimalApi.ApplicationServices.Services;
using MinimalApi.Data.Repositories;
using MinimalApi.Domain.Repositories;

namespace MinimalApi.Extensions
{
    public static class MinimalApiDIExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoApplicationServices, AlunoApplicationServices>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioApplicationServices, UsuarioApplicationServices>();
            services.AddScoped<ITokenServices, TokenServices>();

            return services;
        }
    }
}
