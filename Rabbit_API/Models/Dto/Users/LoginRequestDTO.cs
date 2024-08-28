using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Users
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
