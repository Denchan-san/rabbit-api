using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto
{
    public class CreateThreadDTO
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ImageUrl { get; set; } = "https://i.pinimg.com/736x/9f/6f/0d/9f6f0df5b26ddab4258cc55d2f3529c1.jpg";
        //[Required]
        public int? UserId { get; set; }
    }
}
