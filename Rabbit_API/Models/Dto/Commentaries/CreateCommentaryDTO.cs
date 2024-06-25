using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Commentary
{
    public class CreateCommentaryDTO
    {
        [Required]
        public string Content { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
    }
}
