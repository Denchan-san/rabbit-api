using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Threads
{
    public class ThreadDTO
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        //public string? ImageUrl { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
    }
}
