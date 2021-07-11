using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace PlanthorWebApiServer.Hubs
{
    /// <summary>
    /// TODO: Implement SignalR to auto-fetch Tribe Goals
    /// </summary>
    public class TribeGoalsHub : Hub
    {

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            // await Clients.Caller.SendAsync()
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            // await Clients.Caller.SendAsync();
        }

    }
}