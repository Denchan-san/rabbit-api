using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rabbit_API.Models
{
    public class Reply
    {
        [Key]
        public int ID { get; set; }

        //[ForeignKey("ParentalCommentaryId")]
        public Commentary? ParentalCommentary { get; set; }
        public int? ParentalCommentaryId { get; set; }

        //[ForeignKey("ChildCommentaryId")]
        public Commentary? ChildCommentary { get; set; }
        public int? ChildCommentaryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
