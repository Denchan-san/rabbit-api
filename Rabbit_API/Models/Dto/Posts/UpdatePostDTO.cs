using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Posts
{
    public class UpdatePostDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
