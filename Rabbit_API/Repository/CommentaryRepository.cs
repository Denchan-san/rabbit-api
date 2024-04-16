using Rabbit_API.Data;
using Rabbit_API.Models;
using Rabbit_API.Repository.IRepository;

namespace Rabbit_API.Repository
{
    public class CommentaryRepository : Repository<Commentary>, ICommentaryRepository
    {
        private readonly ApplicationDbContext _db;
        public CommentaryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Commentary> UpdateAsync(Commentary entity)
        {
            _db.Commentaries.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
