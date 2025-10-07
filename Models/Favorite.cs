using System.ComponentModel.DataAnnotations;
namespace Hyper_Radio_API.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId_FK { get; set; }
        public User User { get; set; }
        [Required]
        public int TrackId_FK { get; set; }
        public Track Track { get; set; }
    }
}
