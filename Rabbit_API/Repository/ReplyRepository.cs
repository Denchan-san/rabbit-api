using Microsoft.EntityFrameworkCore;
using Rabbit_API.Data;
using Rabbit_API.Models;
using Rabbit_API.Repository.IRepository;

namespace Rabbit_API.Repository
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        private readonly ApplicationDbContext _db;
        public ReplyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Reply> UpdateAsync(Reply entity)
        {
            _db.Replies.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public void Detach(Reply entity)
        {
            var entry = _db.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }

    }
}
