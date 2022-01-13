using Microsoft.AspNetCore.SignalR;

namespace _SignalRCpuDev.Server.Hubs
{
    public class ServiceHub : Hub
    {
        public async Task SendText(string text)
        {
            //send text
            await Clients.Others.SendAsync("ReceiveText", text);
        }
    }
}
