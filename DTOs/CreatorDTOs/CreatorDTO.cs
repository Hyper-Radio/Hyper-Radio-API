using System.ComponentModel.DataAnnotations;

namespace Hyper_Radio_API.DTOs.CreatorDTOs
{
    public class CreatorDTO
    {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Description { get; set; }
        public string? ProfilePictureURL { get; set; }
    }
}
