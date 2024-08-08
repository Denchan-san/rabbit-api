using Rabbit_API.Models;

namespace Rabbit_API.Repository.IRepository
{
    public interface IThreadRepository: IRepository<Models.Thread>
    {
        Task<Models.Thread> UpdateAsync(Models.Thread thread);
        public void Detach(Models.Thread entity);
    }
}
