using Domain.Entities.Common;

namespace Domain.Entities;

public class Feature: BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Title2 { get; set; }
    public string Description2 { get; set; }
    public string Title3 { get; set; }
    public string Description3 { get; set; }
}