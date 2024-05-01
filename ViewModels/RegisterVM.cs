using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventManagementSystem.ViewModels;

public class RegisterVM
{
    [Required]
    public string? Name { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [DisplayName("Confirm Password")]
    public string? ConfirmPassword { get; set; }
}