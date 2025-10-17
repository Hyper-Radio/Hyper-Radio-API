namespace Hyper_Radio_API.DTOs.TrackDTOs;

public class ReadTrackDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public string TrackURL { get; set; }
    public string? ImageURL { get; set; }
    public int CreatorId_FK { get; set; }
}