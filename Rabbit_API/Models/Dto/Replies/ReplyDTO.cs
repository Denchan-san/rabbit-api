using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Posts
{
    public class ReplyDTO
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Content { get; set; }
        //[ForeignKey("ParentalCommentaryId")]
        public Models.Commentary? ParentalCommentary { get; set; }
        public int? ParentalCommentaryId { get; set; }
        //[ForeignKey("ChildCommentaryId")]
        public Models.Commentary? ChildCommentary { get; set; }
        public int? ChildCommentaryId { get; set; }
        //[ForeignKey("ChildUserId")]
        public Models.LocalUser User { get; set; }
        public int? UserId { get; set; }
    }
}
