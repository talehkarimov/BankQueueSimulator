using BankQueue.Core.Interfaces;
using BankQueue.Core.Models;
using BankQueue.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BankQueue.Application.Services;

public sealed class QueueService(
    IQueueRepository queueRepository,
    ICacheService cacheService,
    IHubContext<QueueHub> hubContext) : IQueueService
{
    public async Task AddTicketToQueueAsync(Ticket ticket)
    {
        await queueRepository.AddAsync(ticket);
        await cacheService.AddTicketToCacheAsync(ticket);
        await hubContext.Clients.All.SendAsync("TicketAdded", ticket);
    }

    public async Task<Ticket> AssignTicketToCounterAsync(int counterId)
    {
        var ticket = await queueRepository.AssignTicketToCounterAsync(counterId);
        await cacheService.RemoveTicketFromCacheAsync(ticket.Id);
        await hubContext.Clients.All.SendAsync("TicketAssigned", ticket);
        return ticket;
    }
}
