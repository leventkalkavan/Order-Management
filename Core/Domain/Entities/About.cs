using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Common;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities;

public class About: BaseEntity
{
    public string ImageUrl { get; set; }
    
    // [NotMapped]
    // public IFormFile? Image { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}