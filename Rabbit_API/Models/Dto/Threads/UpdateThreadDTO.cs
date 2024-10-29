using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Threads
{
    public class UpdateThreadDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public byte[]? Image { get; set; }
    }
}
