using System.ComponentModel.DataAnnotations;

namespace Hyper_Radio_API.Models
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ProfilePictureURL { get; set; }
    }
}
