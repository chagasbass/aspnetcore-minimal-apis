using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MinimalApi.Integration.Tests.Bases.Configurations
{
    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
    }
}
