using MinimalApi.ApplicationServices.Contracts;
using MinimalApi.ApplicationServices.Services;
using MinimalApi.Data.Repositories;
using MinimalApi.Domain.Repositories;

namespace MinimalApi.Extensions
{
    public static class MinialApiDIExtensions
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoApplicationServices, AlunoApplicationServices>();

            return services;
        }
    }
}
