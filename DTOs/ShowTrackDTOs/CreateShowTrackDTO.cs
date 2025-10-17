using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.DTOs;

public class CreateShowTrackDTO
{
    public Track Track { get; set; }
    public int Order { get; set; }
    public float FadeIn { get; set; }
    public float FadeOut { get; set; }
    public int TrackId { get; set; }
    public int ShowId { get; set; }
}