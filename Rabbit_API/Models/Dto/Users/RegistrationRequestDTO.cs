namespace Rabbit_API.Models.Dto.Users
{
    public class RegistrationRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
