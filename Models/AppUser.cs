using System.ComponentModel.DataAnnotations;
using EventManagementSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace EventManagementSystem.Models;

public class AppUser : IdentityUser
{
    [StringLength(100)]
    [MaxLength(100)]
    [Required]
    public string? Name { get; set; }
    
    public string? Address { get; set; }
}