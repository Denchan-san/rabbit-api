using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Posts
{
    public class CreatePostDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int? ThreadId { get; set; }
        public int? UserId { get; set; }
    }
}
