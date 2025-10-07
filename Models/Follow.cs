using System.ComponentModel.DataAnnotations;

namespace Hyper_Radio_API.Models
{
    public class Follow
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId_FK { get; set; }
        public User User { get; set; }
        [Required]
        public int CreatorId_FK { get; set; }
        public Creator Creator { get; set; }
    }
}
