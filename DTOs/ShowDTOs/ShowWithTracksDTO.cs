using Hyper_Radio_API.DTOs.TrackDTOs;

namespace Hyper_Radio_API.DTOs.ShowDTOs
{
    public class ShowWithTracksDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TrackDTO> Tracks { get; set; }
    }
}
