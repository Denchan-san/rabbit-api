using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Commentary
{
    public class CommentaryDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        //[ForeignKey("Posts")]
        public Post? Post { get; set; }
        public int? PostId { get; set; }
        //[ForeignKey("Users")]
        public ApplicationUser? User { get; set; }
        public string? UserId { get; set; }
    }
}
