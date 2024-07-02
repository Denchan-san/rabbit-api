using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rabbit_API.Models
{
    public class Thread
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? ImageUrl { get; set; } = "https://i.pinimg.com/736x/9f/6f/0d/9f6f0df5b26ddab4258cc55d2f3529c1.jpg";
        //[ForeignKey("Users")]
        public LocalUser? User { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
