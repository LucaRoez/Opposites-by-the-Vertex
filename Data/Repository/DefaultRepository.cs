using Opuestos_por_el_Vertice.Data.Entities;

namespace Opuestos_por_el_Vertice.Data.Repository
{
    public class DefaultRepository : IRepository
    {
        private readonly PostingDbContext _dbContext;
        public DefaultRepository(PostingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(List<Post> posts)
        {
            _dbContext.AddRange(posts);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(List<Post> posts)
        {
            _dbContext.RemoveRange(posts);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(List<Post> posts)
        {
            _dbContext.UpdateRange(posts);
            await _dbContext.SaveChangesAsync();
        }

        public List<Post> DetailAll() => _dbContext.Posts.ToList();

        public async Task<Post> DetailOne(int id) => await _dbContext.Posts.FindAsync(id);
    }
}
