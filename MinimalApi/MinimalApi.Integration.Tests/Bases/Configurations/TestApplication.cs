using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MinimalApi.Extensions;
using ProjetoCompeticao.Integration.Tests.Bases.Extensions;
using System;
using System.Net.Http;

namespace MinimalApi.Integration.Tests.Bases.Configurations
{
    internal class TestApplication : WebApplicationFactory<Program>
    {
        private const string urlValue = @"https://localhost:5001/";

        protected override IHost CreateHost(IHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                services.AddDependencyInjection()
                        .AddIntegrationDbContextInMemory();
            });

            return base.CreateHost(builder);
        }

        public new HttpClient CreateClient()
        {
            var _client = this.CreateDefaultClient();
            _client.BaseAddress = new Uri(urlValue);

            return _client;
        }
    }
}
