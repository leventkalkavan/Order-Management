using Domain.Entities.Common;

namespace Domain.Entities;

public class Booking: BaseEntity
{
    public string Name { get; set; }
    public string Telephone { get; set; }
    public string? Email { get; set; }
    public int PersonCount { get; set; }
    public DateTime Date { get; set; }
}