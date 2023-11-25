using Domain.Entities.Common;

namespace Domain.Entities;

public class Notification: BaseEntity
{
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}