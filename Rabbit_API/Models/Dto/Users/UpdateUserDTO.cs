using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Users
{
    public class UpdateUserDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string AvatarUrl { get; set; } 
    }
}
