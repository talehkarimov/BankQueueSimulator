using BankQueue.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BankQueue.Infrastructure.Data;

public sealed class BankQueueDbContext : DbContext
{
    public BankQueueDbContext(DbContextOptions<BankQueueDbContext> options)
         : base(options)
    { }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Counter> Counters { get; set; }
}
