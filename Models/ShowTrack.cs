using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Hyper_Radio_API.Models;

public class ShowTrack
{
    [Key] 
    public int Id { get; set; }
    [Required]
    public int ShowId { get; set; }
    [Required]
    public int TrackId { get; set; }
    
    [Required]
    public int Order { get; set; }
    [Required]
    public float FadeIn { get; set; }
    [Required]
    public float FadeOut { get; set; }
    
    // Navigation props
    public Show Show { get; set; }
    public Track Track { get; set; }

    
    
}