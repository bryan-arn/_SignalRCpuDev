using _SignalRCpuDev.Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace _SignalRCpuDev.Server
{
    public class SignalRCpuDevService : BackgroundService
    {
        private readonly IHubContext<ServiceHub> _hubContext;

        public SignalRCpuDevService(IHubContext<ServiceHub> hubContext)
        {
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                //send current time every second
                await _hubContext.Clients.All.SendAsync("ReceiveText", DateTime.Now.ToString());

                await Task.Delay(1000, stoppingToken);

            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}
