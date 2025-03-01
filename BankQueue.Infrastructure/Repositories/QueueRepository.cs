using BankQueue.Core.Interfaces;
using BankQueue.Core.Models;
using BankQueue.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BankQueue.Infrastructure.Repositories;

public sealed class QueueRepository : IQueueRepository
{
    private readonly BankQueueDbContext _context;

    public QueueRepository(BankQueueDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
    }

    public async Task<Ticket> AssignTicketToCounterAsync(int counterId)
    {
        var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.QueuePosition == 1);
        if (ticket != null)
        {
            ticket.QueuePosition = 0;
            await _context.SaveChangesAsync();
        }
        return ticket;
    }
}

