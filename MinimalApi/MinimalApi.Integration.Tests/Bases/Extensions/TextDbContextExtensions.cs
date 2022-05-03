using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoCompeticao.Integration.Tests.Bases.TestContexts;

namespace ProjetoCompeticao.Integration.Tests.Bases.Extensions
{
    public static class TextDbContextExtensions
    {
        public static IServiceCollection AddIntegrationDbContextInMemory(this IServiceCollection services)
        {
            services.AddDbContext<IntegrationTestDataContext>(opt => opt.UseInMemoryDatabase("DbIntegrationTests"));

            return services;
        }
    }
}
