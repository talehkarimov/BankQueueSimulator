using BankQueue.Core.Models;

namespace BankQueue.Core.Interfaces;

public interface ICacheService
{
    Task<IEnumerable<Ticket>> GetQueueAsync();
    Task AddTicketToCacheAsync(Ticket ticket);
    Task RemoveTicketFromCacheAsync(int ticketId);
}
