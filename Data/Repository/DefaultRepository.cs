using Opuestos_por_el_Vertice.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Opuestos_por_el_Vertice.Data.Repository
{
    public class DefaultRepository : IRepository
    {
        private readonly PostingDbContext _dbContext;
        private static Dictionary<string, Func<BasePost, BasePost>> _reset = new Dictionary<string, Func<BasePost, BasePost>>
        {
                { "Artist", GetArtistData },
                { "Album", GetAlbumData },
                { "Genre", GetGenreData },
                { "Event", GetEventData },
                { "New", GetNewData }
        };
        public DefaultRepository(PostingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private static BasePost GetNewData(BasePost oldData)
        {
            New newData = new();
            {
                newData.Title = oldData.Title;
                newData.SubTitle = oldData.SubTitle;
                newData.Body = oldData.Body;
                newData.Image = oldData.Image;
                newData.ImageAlt = oldData.ImageAlt;
                newData.PublicationDate = oldData.PublicationDate;
                newData.Author = oldData.Author;
                newData.CategoryId = 1;
                newData.Rate = oldData.Rate;
            }
            return newData;
        }
        private static BasePost GetEventData(BasePost oldData)
        {
            Event newData = new();
            {
                newData.Title = oldData.Title;
                newData.SubTitle = oldData.SubTitle;
                newData.Body = oldData.Body;
                newData.Image = oldData.Image;
                newData.ImageAlt = oldData.ImageAlt;
                newData.PublicationDate = oldData.PublicationDate;
                newData.Author = oldData.Author;
                newData.CategoryId = 2;
                newData.Rate = oldData.Rate;
            }
            return newData;

        }
        private static BasePost GetArtistData(BasePost oldData)
        {
            Artist newData = new();
            {
                newData.Title = oldData.Title;
                newData.SubTitle = oldData.SubTitle;
                newData.Body = oldData.Body;
                newData.Image = oldData.Image;
                newData.ImageAlt = oldData.ImageAlt;
                newData.PublicationDate = oldData.PublicationDate;
                newData.Author = oldData.Author;
                newData.CategoryId = 3;
                newData.Rate = oldData.Rate;
            }
            return newData;
        }
        private static BasePost GetAlbumData(BasePost oldData)
        {
            Album newData = new();
            {
                newData.Title = oldData.Title;
                newData.SubTitle = oldData.SubTitle;
                newData.Body = oldData.Body;
                newData.Image = oldData.Image;
                newData.ImageAlt = oldData.ImageAlt;
                newData.PublicationDate = oldData.PublicationDate;
                newData.Author = oldData.Author;
                newData.CategoryId = 4;
                newData.Rate = oldData.Rate;
            }
            return newData;
        }
        private static BasePost GetGenreData(BasePost oldData)
        {
            Genre newData = new();
            {
                newData.Title = oldData.Title;
                newData.SubTitle = oldData.SubTitle;
                newData.Body = oldData.Body;
                newData.Image = oldData.Image;
                newData.ImageAlt = oldData.ImageAlt;
                newData.PublicationDate = oldData.PublicationDate;
                newData.Author = oldData.Author;
                newData.CategoryId = 5;
                newData.Rate = oldData.Rate;
            }
            return newData;
        }

        public async Task Create<TEntity>(BasePost post)where TEntity : BasePost
        {
            //_dbContext.Add(post); // pure TPT implementation
            switch (post)
            {
                case Artist artist: _dbContext.Artists.AddAsync(artist); break;
                case Album album: _dbContext.Albums.AddAsync(album); break;
                case Genre genre: _dbContext.Genres.AddAsync(genre); break;
                case Event @event: _dbContext.Events.AddAsync(@event); break;
                case New @new: _dbContext.News.AddAsync(@new); break;
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

        public List<BasePost> DetailAll(string category) => GetDbContent(category).ToList();

        public async Task<BasePost> DetailOne(string category, int id) => await GetDbContent(category).FirstOrDefaultAsync(p => p.Id == id);

        public List<Category> GetCategories() => _dbContext.Categories.ToList();

        public async Task UnbendDb()
        {
            for (int kind = 0; kind < 5; kind++)
            {
                if (kind == 4)
                {
                    List<Genre> currentData = _dbContext.Genres.Where(g => g.CategoryId != 5).ToList();
                    currentData.ForEach(oldData =>
                    {
                        switch (oldData.CategoryId)
                        {
                            case 4:
                                Album newAlbum = (Album)_reset["Album"](oldData);
                                _dbContext.Genres.Remove(oldData);
                                _dbContext.Albums.Add(newAlbum);
                                break;
                            case 3:
                                Artist newArtist = (Artist)_reset["Artist"](oldData);
                                _dbContext.Genres.Remove(oldData);
                                _dbContext.Artists.Add(newArtist);
                                break;
                            case 2:
                                Event newEvent = (Event)_reset["Event"](oldData);
                                _dbContext.Genres.Remove(oldData);
                                _dbContext.Events.Add(newEvent);
                                break;
                            case 1:
                                New newNew = (New)_reset["New"](oldData);
                                _dbContext.Genres.Remove(oldData);
                                _dbContext.News.Add(newNew);
                                break;
                            default: break;
                        }
                    });
                    await _dbContext.SaveChangesAsync();
                }
                else if (kind == 3)
                {
                    List<Album> currentData = _dbContext.Albums.Where(a => a.CategoryId != 4).ToList();
                    currentData.ForEach(oldData =>
                    {
                        switch (oldData.CategoryId)
                        {
                            case 5:
                                Genre newGenre = (Genre)_reset["Genre"](oldData);
                                _dbContext.Albums.Remove(oldData);
                                _dbContext.Genres.Add(newGenre);
                                break;
                            case 3:
                                Artist newArtist = (Artist)_reset["Artist"](oldData);
                                _dbContext.Albums.Remove(oldData);
                                _dbContext.Artists.Add(newArtist);
                                break;
                            case 2:
                                Event newEvent = (Event)_reset["Event"](oldData);
                                _dbContext.Albums.Remove(oldData);
                                _dbContext.Events.Add(newEvent);
                                break;
                            case 1:
                                New newNew = (New)_reset["New"](oldData);
                                _dbContext.Albums.Remove(oldData);
                                _dbContext.News.Add(newNew);
                                break;
                            default: break;
                        }
                    });
                    await _dbContext.SaveChangesAsync();
                }
                else if (kind == 2)
                {
                    List<Artist> currentData = _dbContext.Artists.Where(a => a.CategoryId != 3).ToList();
                    currentData.ForEach(oldData =>
                    {
                        switch (oldData.CategoryId)
                        {
                            case 5:
                                Genre newGenre = (Genre)_reset["Genre"](oldData);
                                _dbContext.Artists.Remove(oldData);
                                _dbContext.Genres.Add(newGenre);
                                break;
                            case 4:
                                Album newAlbum = (Album)_reset["Album"](oldData);
                                _dbContext.Artists.Remove(oldData);
                                _dbContext.Albums.Add(newAlbum);
                                break;
                            case 2:
                                Event newEvent = (Event)_reset["Event"](oldData);
                                _dbContext.Artists.Remove(oldData);
                                _dbContext.Events.Add(newEvent);
                                break;
                            case 1:
                                New newNew = (New)_reset["New"](oldData);
                                _dbContext.Artists.Remove(oldData);
                                _dbContext.News.Add(newNew);
                                break;
                            default: break;
                        }
                    });
                    await _dbContext.SaveChangesAsync();
                }
                else if (kind == 1)
                {
                    List<Event> currentData = _dbContext.Events.Where(a => a.CategoryId != 2).ToList();
                    currentData.ForEach(oldData =>
                    {
                        switch (oldData.CategoryId)
                        {
                            case 5:
                                Genre newGenre = (Genre)_reset["Genre"](oldData);
                                _dbContext.Events.Remove(oldData);
                                _dbContext.Genres.Add(newGenre);
                                break;
                            case 4:
                                Album newAlbum = (Album)_reset["Album"](oldData);
                                _dbContext.Events.Remove(oldData);
                                _dbContext.Albums.Add(newAlbum);
                                break;
                            case 3:
                                Artist newArtist = (Artist)_reset["Artist"](oldData);
                                _dbContext.Events.Remove(oldData);
                                _dbContext.Artists.Add(newArtist);
                                break;
                            case 1:
                                New newNew = (New)_reset["New"](oldData);
                                _dbContext.Events.Remove(oldData);
                                _dbContext.News.Add(newNew);
                                break;
                            default: break;
                        }
                    });
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    List<New> currentData = _dbContext.News.Where(n => n.CategoryId != 1).ToList();
                    currentData.ForEach(oldData =>
                    {
                        switch (oldData.CategoryId)
                        {
                            case 5:
                                Genre newGenre = (Genre)_reset["Genre"](oldData);
                                _dbContext.News.Remove(oldData);
                                _dbContext.Genres.Add(newGenre);
                                break;
                            case 4:
                                Album newAlbum = (Album)_reset["Album"](oldData);
                                _dbContext.News.Remove(oldData);
                                _dbContext.Albums.Add(newAlbum);
                                break;
                            case 3:
                                Artist newArtist = (Artist)_reset["Artist"](oldData);
                                _dbContext.News.Remove(oldData);
                                _dbContext.Artists.Add(newArtist);
                                break;
                            case 2:
                                Event newEvent = (Event)_reset["Event"](oldData);
                                _dbContext.News.Remove(oldData);
                                _dbContext.Events.Add(newEvent);
                                break;
                            default: break;
                        }
                    });
                    await _dbContext.SaveChangesAsync();
                }
            }
        }


        private IQueryable<BasePost> GetDbContent(string category) => category switch
        {
            "Artist" => _dbContext.Artists.Include(p => p.Category).Cast<BasePost>(),
            "Album" => _dbContext.Albums.Include(p => p.Category).Cast<BasePost>(),
            "Genre" => _dbContext.Genres.Include(p => p.Category).Cast<BasePost>(),
            "Event" => _dbContext.Events.Include(p => p.Category).Cast<BasePost>(),
            "New" => _dbContext.News.Include(p => p.Category).Cast<BasePost>(),
        };
    }
}
