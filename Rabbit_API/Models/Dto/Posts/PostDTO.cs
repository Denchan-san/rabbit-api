using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Posts
{
    public class PostDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        //[ForeignKey("Threads")]
        public Thread? Thread { get; set; }
        public int? ThreadId { get; set; }
        //[ForeignKey("Users")]
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
