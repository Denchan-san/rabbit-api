namespace Rabbit_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ThreadId { get; set; }
    }
}
