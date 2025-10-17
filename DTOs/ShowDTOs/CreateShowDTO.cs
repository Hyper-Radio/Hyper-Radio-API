using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.DTOs.ShowDTOs;

public class CreateShowDTO
{
    public string Name { get; set; }
    public DateTime ScheduledStart { get; set; }
    public List<ShowTrack> Tracks { get; set; } = new();
}