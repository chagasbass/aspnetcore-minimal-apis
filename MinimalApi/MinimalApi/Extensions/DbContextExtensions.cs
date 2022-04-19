using Microsoft.EntityFrameworkCore;
using MinimalApi.Data.DataContext;

namespace MinimalApi.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContextInMemory(this IServiceCollection services)
        {
            services.AddDbContext<MinimalApiDataContext>(opt => opt.UseInMemoryDatabase("DbMinimalApi"));

            return services;
        }
    }
}
