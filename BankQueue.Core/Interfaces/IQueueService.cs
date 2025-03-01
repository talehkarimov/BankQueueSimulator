using BankQueue.Core.Models;

namespace BankQueue.Core.Interfaces;

public interface IQueueService
{
    Task AddTicketToQueueAsync(Ticket ticket);
    Task<Ticket> AssignTicketToCounterAsync(int counterId);
}
