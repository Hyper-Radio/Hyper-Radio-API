using System.ComponentModel.DataAnnotations;

namespace Hyper_Radio_API.Models;

public class Show
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime ScheduledStart { get; set; }
    
    [Required]
    public ICollection<ShowTrack> ShowTracks { get; set; }

    
}