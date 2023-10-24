using Opuestos_por_el_Vertice.Data.Entities;
using Microsoft.EntityFrameworkCore;

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
                case "Artist": return _dbContext.Artists.Include(p => p.Category).ToList<BasePost>();
                case "Album": return _dbContext.Albums.Include(p => p.Category).ToList<BasePost>();
                case "Genre": return _dbContext.Genres.Include(p => p.Category).ToList<BasePost>();
                case "Event": return _dbContext.Events.Include(p => p.Category).ToList<BasePost>();
                case "New": return _dbContext.News.Include(p => p.Category).ToList<BasePost>();
                default: return _dbContext.News.Include(p => p.Category).ToList<BasePost>();
            }
        }

        public async Task<BasePost> DetailOne(string category, int id)
        {
            switch (category)
            {
                case "Artist": return await _dbContext.Artists.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
                case "Album": return await _dbContext.Albums.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
                case "Genre": return await _dbContext.Genres.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
                case "Event": return await _dbContext.Events.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
                case "New": return await _dbContext.News.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
                default: return await _dbContext.News.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            }
        }
    }
}
