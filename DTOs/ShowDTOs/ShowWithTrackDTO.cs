using Hyper_Radio_API.DTOs.TrackDTOs;
using Hyper_Radio_API.Models;

namespace Hyper_Radio_API.DTOs.ShowDTOs
{
    public class ShowWithTrackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TrackDTO> Tracks { get; set; }
    }
}
