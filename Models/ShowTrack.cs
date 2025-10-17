using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Models;

public class ShowTrack
{
    [Key] 
    public int Id { get; set; }
    [Required]
    public Track Track { get; set; }
    [Required]
    public int Order { get; set; }
    [Required]
    public float FadeIn { get; set; }
    [Required]
    public float FadeOut { get; set; }
    [Required] 
    public int Bitrate { get; set; } = 128; 
}