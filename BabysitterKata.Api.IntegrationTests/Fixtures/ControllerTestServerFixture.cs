using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace BabysitterKata.Api.IntegrationTests.Fixtures
{
    public class ControllerTestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;

        public ControllerTestServerFixture()
        {
            var builder = CreateWebHostBuilder(null);

            _testServer = new TestServer(builder);

            Client = _testServer.CreateClient();
        }

        public HttpClient Client {get; }

        private IWebHostBuilder CreateWebHostBuilder(String[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<StartupBase>();

        public void Dispose()
        {
            _testServer.Dispose();

            Client.Dispose();
        }
    }
}
