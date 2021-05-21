using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace LudoWeb.Hubs
{
    public class LobbyMessageHub : Hub
    {
        public async Task BroadcastMessage(string gameId, string information)
        {
            await Clients.All.SendAsync("ReceiveMessage", gameId, information);
        }
    }
}