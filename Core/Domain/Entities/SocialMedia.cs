using Domain.Entities.Common;

namespace Domain.Entities;

public class SocialMedia : BaseEntity
{
    public string Title { get; set; }
    public string Url { get; set; }
    public string Icon { get; set; }
}