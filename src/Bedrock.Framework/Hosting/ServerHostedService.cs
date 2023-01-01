using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Bedrock.Framework
{
    public class ServerHostedService : IHostedService
    {
        private readonly Server _server;

        public ServerHostedService(IOptions<ServerHostedServiceOptions> options)
        {
            _server = options.Value.ServerBuilder.Build();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return _server.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _server.StopAsync(cancellationToken);
        }

        public Task AddSocketListenerAsync(IPAddress address, int port, Action<IConnectionBuilder> configure)
        {
            return _server.AddSocketListenerAsync(address, port, configure);
        }

        public Task RemoveSocketListenerAsync(IPAddress address, int port)
        {
            return _server.RemoveSocketListener(address, port);
        }
    }
}
