using Rabbit_API.Models;

namespace Rabbit_API.Repository.IRepository
{
    public interface IReplyRepository: IRepository<Reply>
    {
        Task<Reply> UpdateAsync(Reply reply);
        public void Detach(Reply entity);
    }
}
