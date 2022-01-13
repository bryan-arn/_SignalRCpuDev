using Microsoft.AspNetCore.SignalR.Client;

namespace _SignalRCpuDev.Server
{
    public class SignalRCpuDevService : BackgroundService
    {
        private HubConnection _serviceHubConnection;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _serviceHubConnection = new HubConnectionBuilder()
                    .WithUrl($"http://127.0.0.1:5244/serviceHub") //change port to project port
                    .Build();
            
            await _serviceHubConnection.StartAsync(stoppingToken);

            do
            {
                //send current time every second
                if (_serviceHubConnection != null)
                    await _serviceHubConnection.InvokeAsync("SendText", DateTime.Now.ToString(), stoppingToken);

                await Task.Delay(1000, stoppingToken);

            } while (!stoppingToken.IsCancellationRequested);
        }
    }
}
