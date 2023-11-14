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
        public async Task Create<TEntity>(BasePost post) where TEntity : BasePost
        {
            //_dbContext.Add(post); // pure TPT implementation
            switch (post)
            {
                case Artist artist: _dbContext.Artists.Add(artist); break;
                case Album album: _dbContext.Albums.Add(album); break;
                case Genre genre: _dbContext.Genres.Add(genre); break;
                case Event @event: _dbContext.Events.Add(@event); break;
                case New @new: _dbContext.News.Add(@new); break;
                default: break;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(BasePost post)
        {
            _dbContext.Remove(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAll(string identifier)
        {
            switch (identifier)
            {
                case "Genres": _dbContext.Genres.RemoveRange(_dbContext.Genres); break;
                case "Albums": _dbContext.Albums.RemoveRange(_dbContext.Albums); break;
                case "Artists": _dbContext.Artists.RemoveRange(_dbContext.Artists); break;
                case "Events": _dbContext.Events.RemoveRange(_dbContext.Events); break;
                case "News": _dbContext.News.RemoveRange(_dbContext.News); break;
                default: _dbContext.Genres.RemoveRange(_dbContext.Genres); _dbContext.Albums.RemoveRange(_dbContext.Albums);
                    _dbContext.Artists.RemoveRange(_dbContext.Artists); _dbContext.Events.RemoveRange(_dbContext.Events);
                    _dbContext.News.RemoveRange(_dbContext.News); break;
            }
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

        public List<Category> GetCategories() => _dbContext.Categories.ToList();

        public async Task ArrangeDb()
        {
            for (int kind = 0; kind < 5; kind++)
            {
                if (kind == 4)
                {
                    List<Genre> currentData = _dbContext.Genres.Where(g => g.CategoryId != 5).ToList();
                    foreach (Genre oldaData in currentData)
                    {
                        if (oldaData.CategoryId == 4)
                        {
                            Album newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 4;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Genres.Remove(oldaData);
                            await _dbContext.Albums.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 3)
                        {
                            Artist newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 3;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Genres.Remove(oldaData);
                            await _dbContext.Artists.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 2)
                        {
                            Event newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 2;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Genres.Remove(oldaData);
                            await _dbContext.Events.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 1)
                        {
                            New newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 1;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Genres.Remove(oldaData);
                            await _dbContext.News.AddAsync(newData);
                        }
                        else { continue; }
                        await _dbContext.SaveChangesAsync();
                    }
                }
                else if (kind == 3)
                {
                    List<Album> currentData = _dbContext.Albums.Where(a => a.CategoryId != 4).ToList();
                    foreach (Album oldaData in currentData)
                    {
                        if (oldaData.CategoryId == 5)
                        {
                            Genre newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 5;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Albums.Remove(oldaData);
                            await _dbContext.Genres.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 3)
                        {
                            Artist newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 3;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Albums.Remove(oldaData);
                            await _dbContext.Artists.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 2)
                        {
                            Event newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 2;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Albums.Remove(oldaData);
                            await _dbContext.Events.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 1)
                        {
                            New newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 1;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Albums.Remove(oldaData);
                            await _dbContext.News.AddAsync(newData);
                        }
                        else { continue; }
                        await _dbContext.SaveChangesAsync();
                    }
                }
                else if (kind == 2)
                {
                    List<Artist> currentData = _dbContext.Artists.Where(a => a.CategoryId != 3).ToList();
                    foreach (Artist oldaData in currentData)
                    {
                        if (oldaData.CategoryId == 5)
                        {
                            Genre newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 5;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Artists.Remove(oldaData);
                            await _dbContext.Genres.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 4)
                        {
                            Album newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 4;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Artists.Remove(oldaData);
                            await _dbContext.Albums.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 2)
                        {
                            Event newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 2;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Artists.Remove(oldaData);
                            await _dbContext.Events.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 1)
                        {
                            New newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 1;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Artists.Remove(oldaData);
                            await _dbContext.News.AddAsync(newData);
                        }
                        else { continue; }
                        await _dbContext.SaveChangesAsync();
                    }
                }
                else if (kind == 1)
                {
                    List<Event> currentData = _dbContext.Events.Where(a => a.CategoryId != 2).ToList();
                    foreach (Event oldaData in currentData)
                    {
                        if (oldaData.CategoryId == 5)
                        {
                            Genre newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 5;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Events.Remove(oldaData);
                            await _dbContext.Genres.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 4)
                        {
                            Album newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 4;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Events.Remove(oldaData);
                            await _dbContext.Albums.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 3)
                        {
                            Artist newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 3;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Events.Remove(oldaData);
                            await _dbContext.Artists.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 1)
                        {
                            New newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 1;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.Events.Remove(oldaData);
                            await _dbContext.News.AddAsync(newData);
                        }
                        else { continue; }
                        await _dbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    List<New> currentData = _dbContext.News.Where(n => n.CategoryId != 1).ToList();
                    foreach (New oldaData in currentData)
                    {
                        if (oldaData.CategoryId == 5)
                        {
                            Genre newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 5;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.News.Remove(oldaData);
                            await _dbContext.Genres.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 4)
                        {
                            Album newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 4;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.News.Remove(oldaData);
                            await _dbContext.Albums.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 3)
                        {
                            Artist newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 3;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.News.Remove(oldaData);
                            await _dbContext.Artists.AddAsync(newData);
                        }
                        else if (oldaData.CategoryId == 2)
                        {
                            Event newData = new();
                            {
                                newData.Title = oldaData.Title;
                                newData.SubTitle = oldaData.SubTitle;
                                newData.Body = oldaData.Body;
                                newData.Image = oldaData.Image;
                                newData.ImageAlt = oldaData.ImageAlt;
                                newData.PublicationDate = oldaData.PublicationDate;
                                newData.Author = oldaData.Author;
                                newData.CategoryId = 2;
                                newData.Rate = oldaData.Rate;
                            }
                            _dbContext.News.Remove(oldaData);
                            await _dbContext.Events.AddAsync(newData);
                        }
                        else { continue; }
                        await _dbContext.SaveChangesAsync();
                    }

                }
            }
        }
    }
}
