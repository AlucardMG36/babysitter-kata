using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BabysitterKata.App.IntegrationTests.Fixtures
{
    public class ControllerTestServerFixture: IDisposable
    {
        private TestServer _testServer;

        public ControllerTestServerFixture()
        {
            _testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _testServer.CreateClient();
        }

        public HttpClient Client { get; }
        
        public void Dispose()
        {
            Client?.Dispose();
            _testServer?.Dispose();
        }
    }
}
