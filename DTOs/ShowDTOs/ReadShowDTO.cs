using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.DTOs.ShowDTOs;

public class ReadShowDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime ScheduledStart { get; set; }
    public ICollection<ShowTrack> ShowTracks { get; set; }
}