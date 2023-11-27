using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity;

public class AppUser: IdentityUser
{
    [EmailAddress]
    public override string Email { get; set; }
}