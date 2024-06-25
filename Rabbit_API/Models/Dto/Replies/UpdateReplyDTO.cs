using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Posts
{
    public class UpdateReplyDTO
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
