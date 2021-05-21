using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace LudoAPI.Networking
{
    public class UpdateHub : Hub
    {
        public async Task BroadcastMessage(string gameId, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", gameId, message);
        }
    }
}