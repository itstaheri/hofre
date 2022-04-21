using Frameworks.Auth;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Hofre.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IAuth _auth;
        public async Task SendMessage(string text)
        {
           await Clients.All.SendAsync("Wellcome", $"{_auth.CurrentUserId()} : {text}");
           //await Clients.All.SendAsync("ReceiveMessage", $"{_auth.CurrentUserId()} : {text}");

        }
    }
}
