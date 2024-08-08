using Rabbit_API.Models;

namespace Rabbit_API.Repository.IRepository
{
    public interface ICommentaryRepository: IRepository<Commentary>
    {
        Task<Commentary> UpdateAsync(Commentary commentary);
        public void Detach(Commentary entity);
    }
}
