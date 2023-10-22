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
        public async Task Create(BasePost post)
        {
            _dbContext.Add(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(BasePost post)
        {
            _dbContext.Remove(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(BasePost post)
        {
            _dbContext.Update(post);
            await _dbContext.SaveChangesAsync();
        }

        public List<BasePost> DetailAll(string category)
        {
            switch (category)
            {
                case "Artist": return _dbContext.Artists.ToList<BasePost>();
                case "Album": return _dbContext.Albums.ToList<BasePost>();
                case "Genre": return _dbContext.Genres.ToList<BasePost>();
                case "Event": return _dbContext.Events.ToList<BasePost>();
                case "New": return _dbContext.News.ToList<BasePost>();
                default: return _dbContext.News.ToList<BasePost>();
            }
        }

        public async Task<BasePost> DetailOne(string category, int id)
        {
            switch (category)
            {
                case "Artist": return await _dbContext.Artists.FindAsync(id);
                case "Album": return await _dbContext.Albums.FindAsync(id);
                case "Genre": return await _dbContext.Genres.FindAsync(id);
                case "Event": return await _dbContext.Events.FindAsync(id);
                case "New": return await _dbContext.News.FindAsync(id);
                default: return await _dbContext.News.FindAsync(id);
            }
        }
    }
}
