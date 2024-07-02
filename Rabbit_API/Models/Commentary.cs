using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models
{
    public class Commentary
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        //[ForeignKey("Posts")]
        public Post? Post { get; set; }
        public int? PostId { get; set; }
        //[ForeignKey("Users")]
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
