﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Gourmet.Tests
{

        public class InjectionFixture : IDisposable
        {
            private readonly TestServer server;
            private readonly HttpClient client;

            public InjectionFixture()
            {
                server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
                client = server.CreateClient();
            }

            public IServiceProvider ServiceProvider => server.Host.Services;

            public void Dispose()
            {
                Dispose(true);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    server.Dispose();
                    client.Dispose();
                }
            }
        
    }
}
