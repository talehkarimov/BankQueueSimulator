using BankQueue.Core.Models;

namespace BankQueue.Core.Interfaces;

public interface IQueueRepository
{
    Task AddAsync(Ticket ticket); 
    Task<Ticket> AssignTicketToCounterAsync(int counterId); 
}