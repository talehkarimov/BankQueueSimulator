using BankQueue.Core.Interfaces;
using BankQueue.Core.Models;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace BankQueue.Infrastructure.Cache;

public sealed class CacheService(IConnectionMultiplexer redis) : ICacheService
{
    public async Task<IEnumerable<Ticket>> GetQueueAsync()
    {
        var db = redis.GetDatabase();
        var tickets = await db.ListRangeAsync("queue");
        return tickets.Select(t => JsonConvert.DeserializeObject<Ticket>(t));
    }

    public async Task AddTicketToCacheAsync(Ticket ticket)
    {
        var db = redis.GetDatabase();
        await db.ListRightPushAsync("queue", JsonConvert.SerializeObject(ticket));
    }

    public async Task RemoveTicketFromCacheAsync(int ticketId)
    {
        var db = redis.GetDatabase();
        var queue = await db.ListRangeAsync("queue");
        var ticket = queue.FirstOrDefault(t => JsonConvert.DeserializeObject<Ticket>(t).Id == ticketId);
        await db.ListRemoveAsync("queue", ticket);
    }
}
