using Microsoft.EntityFrameworkCore;
using Rabbit_API.Data;
using Rabbit_API.Models;
using Rabbit_API.Repository.IRepository;

namespace Rabbit_API.Repository
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly ApplicationDbContext _db;
        public PostRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Post> UpdateAsync(Post entity)
        {
            _db.Posts.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public void Detach(Post entity)
        {
            var entry = _db.Entry(entity);
            if (entry != null)
            {
                entry.State = EntityState.Detached;
            }
        }

    }
}
