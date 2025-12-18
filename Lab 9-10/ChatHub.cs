using Microsoft.AspNetCore.SignalR;

namespace SignalRApp
{
    /// <summary>
    /// Хаб- основная единица в SignalRApp
    /// </summary>
    public class ChatHub : Hub
    {
        public async Task Send(string message, string userName)
        {
            await Clients.All.SendAsync("Receive", message, userName);
        }
    }
}