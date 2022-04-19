using MinimalApi.Shared;

namespace MinimalApi.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddMinimalApiAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(name: Settings.GetRoleAdmin(), configurePolicy: policy => policy.RequireRole("admin"));
                options.AddPolicy(name: Settings.GetRoleUser(), configurePolicy: policy => policy.RequireRole("user"));
            });

            return services;
        }
    }
}
