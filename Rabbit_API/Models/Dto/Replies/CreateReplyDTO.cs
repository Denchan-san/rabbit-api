using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Posts
{
    public class CreateReplyDTO
    {
        [Required]
        public string Content { get; set; }
        public int? ParentalCommentaryId { get; set; }
        public int? ChildCommentaryId { get; set; }
        public int? UserId { get; set; }
    }
}
