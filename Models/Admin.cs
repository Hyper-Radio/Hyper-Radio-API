using System.ComponentModel.DataAnnotations;

namespace Hyper_Radio_API.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
