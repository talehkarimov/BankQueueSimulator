using BankQueue.Core.Models;
using Microsoft.AspNetCore.SignalR;

namespace BankQueue.Infrastructure.Hubs;

public sealed class QueueHub : Hub
{
    public async Task SendTicketUpdate(Ticket ticket)
    {
        await Clients.All.SendAsync("TicketUpdated", ticket);
    }
}
