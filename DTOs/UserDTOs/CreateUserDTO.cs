namespace Hyper_Radio_API.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ProfilePictureURL { get; set; }
    }
}
