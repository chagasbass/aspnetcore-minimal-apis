using Microsoft.AspNetCore.HttpLogging;

namespace MinimalApi.Extensions
{
    public static class LogExtensions
    {
        public static IServiceCollection AddMinimalApiHttpLogging(this IServiceCollection services)
        {
            HttpLoggingOptions options = new HttpLoggingOptions();
            services.AddHttpLogging(options =>
            {
                options.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders |
                                        HttpLoggingFields.ResponseStatusCode |
                                        HttpLoggingFields.ResponseBody |
                                        HttpLoggingFields.RequestBody;

                options.RequestBodyLogLimit = 4096;
                options.ResponseBodyLogLimit = 4096;
                options.MediaTypeOptions.AddText("application/json");
            });

            return services;
        }
    }
}
