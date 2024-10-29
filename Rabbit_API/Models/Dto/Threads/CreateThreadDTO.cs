using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Threads
{
    public class CreateThreadDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public byte[]? Image { get; set; }
        public string? UserId { get; set; }
    }
}
