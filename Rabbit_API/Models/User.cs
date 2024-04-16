using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Commentary? Commentary { get; set; }
        public string AvatarUrl { get; set; }

    }
}
