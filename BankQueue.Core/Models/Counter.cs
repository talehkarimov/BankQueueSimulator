namespace BankQueue.Core.Models;

public class Counter : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Ticket CurrentTicket { get; set; }
    public bool IsAvailable { get; set; }
}
