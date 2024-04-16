using Rabbit_API.Models;

namespace Rabbit_API.Repository.IRepository
{
    public interface IPostRepository: IRepository<Post>
    {
        Task<Post> UpdateAsync(Post post);
    }
}
