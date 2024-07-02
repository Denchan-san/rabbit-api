using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models
{
    public class Reply
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Content { get; set; }
        //[ForeignKey("ParentalCommentaryId")]
        public Commentary? ParentalCommentary { get; set; }
        public int? ParentalCommentaryId { get; set; }
        //[ForeignKey("ChildCommentaryId")]
        public Commentary? ChildCommentary { get; set; }
        public int? ChildCommentaryId { get; set; }
        //[ForeignKey("ChildUserId")]
        public Models.LocalUser User { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
