using Frameworks.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using TM.Application.Contract.Ticket;

namespace Hofre.Hubs
{
   
    public class ChatHub : Hub
    {
        //  private readonly IAuth _auth;
        private readonly ITicketApplication _app;

        public ChatHub(ITicketApplication app)
        {
            _app = app;
        }

        public override Task OnConnectedAsync()
        {

            Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string receive, string message,string date)
        {
            await Clients.All.SendAsync("ReceiveMessage", receive, message,date);
        }

        public async Task SendMessageToGroup(string sender, string receiver, string message,string date)
        {
            await _app.CreateMessage(new Messages { CreationDate = date, Message = message, Username = sender });
            await Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message,date);
        }


    }
}
