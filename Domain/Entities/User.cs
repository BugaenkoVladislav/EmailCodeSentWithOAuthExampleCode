using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;
[Index(nameof(Email), IsUnique = true)] 
[Index(nameof(PhoneNumber), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class User
{
    [Key]
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; } 
    [Required]
    public string Password { get; set; } 
    [Required]
    public string PhoneNumber { get; set; } 
    [Required]
    public DateTime BirthDate;
}
    
    