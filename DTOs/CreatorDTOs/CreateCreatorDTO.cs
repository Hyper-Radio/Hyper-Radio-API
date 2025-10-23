namespace Hyper_Radio_API.DTOs.CreatorDTOs
{
    public class CreateCreatorDTO
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string? ProfilePictureURL { get; set; }
    }
}
