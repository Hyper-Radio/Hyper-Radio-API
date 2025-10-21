using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hyper_Radio_API.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]

        public int UserId_FK { get; set; }
        public User User { get; set; }
        [Required]
        [ForeignKey("Track")]

        public int TrackId_FK { get; set; }
        public Track Track { get; set; }
    }
}
