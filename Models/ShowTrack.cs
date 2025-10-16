using System.ComponentModel.DataAnnotations;

namespace Hyper_Radio_API.Models;

public class ShowTrack
{
    [Required]
    public Track Track { get; set; }
    [Required]
    public int Order { get; set; }
    [Required]
    public float FadeIn { get; set; }
    [Required]
    public float FadeOut { get; set; }
    [Required] public int Bitrate { get; set; } = 128; 
}