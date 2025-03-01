namespace BankQueue.Core.Models;

public class Ticket : BaseModel
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime IssueTime { get; set; }
    public int QueuePosition { get; set; }
}
