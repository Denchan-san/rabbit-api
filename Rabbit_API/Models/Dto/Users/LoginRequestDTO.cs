using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Users
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
