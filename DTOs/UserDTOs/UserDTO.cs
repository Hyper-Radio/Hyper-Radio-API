using System.ComponentModel.DataAnnotations;

namespace Hyper_Radio_API.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? ProfilePictureURL { get; set; }
    }
}
