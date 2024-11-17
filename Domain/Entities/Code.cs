using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Code
{
    [Key]
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string UserPhoneOrEmail { get; set; }
    [Required]
    public string SentCode { get; set; }
}