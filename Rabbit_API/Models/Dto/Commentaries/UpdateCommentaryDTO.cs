using System.ComponentModel.DataAnnotations;

namespace Rabbit_API.Models.Dto.Commentary
{
    public class UpdateCommentaryDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
