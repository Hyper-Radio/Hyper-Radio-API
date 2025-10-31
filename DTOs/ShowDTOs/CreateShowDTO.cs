namespace Hyper_Radio_API.DTOs.ShowDTOs
{
    public class CreateShowDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledStart { get; set; }

        public List<CreateShowTrackDTO> ShowTracks { get; set; } = new();
    }
}