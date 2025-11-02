using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hyper_Radio_API.Models
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public string TrackURL { get; set; }
        public string? ImageURL { get; set; }
        
        [ForeignKey("Creator")]
        public int? CreatorId_FK { get; set; }
        public Creator? Creator { get; set; }
        
        public ICollection<ShowTrack> ShowTracks { get; set; }
    }
}



