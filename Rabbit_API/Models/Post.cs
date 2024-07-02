using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rabbit_API.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        //[ForeignKey("Threads")]
        public Thread? Thread { get; set; }
        public int? ThreadId { get; set; }

        //[ForeignKey("Users")]
        public LocalUser? User { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
