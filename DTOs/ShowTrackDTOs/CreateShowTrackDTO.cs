namespace Hyper_Radio_API.DTOs.ShowDTOs
{
    public class CreateShowTrackDTO
    {
        public int TrackId { get; set; }   
        public int Order { get; set; }
        public float FadeIn { get; set; }
        public float FadeOut { get; set; }
    }
}