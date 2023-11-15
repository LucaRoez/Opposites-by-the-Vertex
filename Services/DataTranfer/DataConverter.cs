using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Services.DataTranfer
{
    public class DataConverter
    {
        private static Dictionary<string, Func<PostViewModel, BasePost>> postDatas = new()
        {
            { "Artist", GetArtistData },
            { "Album", GetAlbumData },
            { "Genre", GetGenreData },
            { "Event", GetEventData },
            { "New", GetNewData }
        };
        private static Func<BasePost, PostViewModel> postModel = GetModel;

        public static BasePost GetModelData(PostViewModel model)
        {
            if (postDatas.TryGetValue(model.Category, out var postBuilder))
            {
                return postBuilder(model);
            }

            return GetDefaultData(model);
        }

        public static List<BasePost> GetAllModelDatas(List<PostViewModel> models) => models.Select(model => GetModelData(model)).ToList();

        public static PostViewModel GetViewModel(BasePost postData) => postModel(postData);

        public static List<PostViewModel> GetAllViewModels(List<BasePost> datas) => datas.Select(data => GetViewModel(data)).ToList();

        private static Artist GetArtistData(PostViewModel model) => new Artist
        {
            Title = model.Title,
            SubTitle = model.SubTitle,
            Body = model.Body,
            Image = model.Image,
            ImageAlt = model.ImageAlt,
            PublicationDate = model.PublicationDate,
            Author = model.Author,
            CategoryId = 3,
            Rate = model.Rate
        };
        private static Album GetAlbumData(PostViewModel model) => new Album
        {
            Title = model.Title,
            SubTitle = model.SubTitle,
            Body = model.Body,
            Image = model.Image,
            ImageAlt = model.ImageAlt,
            PublicationDate = model.PublicationDate,
            Author = model.Author,
            CategoryId = 4,
            Rate = model.Rate
        };
        private static Genre GetGenreData(PostViewModel model) => new Genre
        {
            Title = model.Title,
            SubTitle = model.SubTitle,
            Body = model.Body,
            Image = model.Image,
            ImageAlt = model.ImageAlt,
            PublicationDate = model.PublicationDate,
            Author = model.Author,
            CategoryId = 5,
            Rate = model.Rate
        };
        private static Event GetEventData(PostViewModel model) => new Event
        {
            Title = model.Title,
            SubTitle = model.SubTitle,
            Body = model.Body,
            Image = model.Image,
            ImageAlt = model.ImageAlt,
            PublicationDate = model.PublicationDate,
            Author = model.Author,
            CategoryId = 2,
            Rate = model.Rate
        };
        private static New GetNewData(PostViewModel model) => new New
        {
            Title = model.Title,
            SubTitle = model.SubTitle,
            Body = model.Body,
            Image = model.Image,
            ImageAlt = model.ImageAlt,
            PublicationDate = model.PublicationDate,
            Author = model.Author,
            CategoryId = 1,
            Rate = model.Rate
        };
        private static New GetDefaultData(PostViewModel model) => new New
        {
            Title = model.Title,
            SubTitle = model.SubTitle,
            Body = model.Body,
            Image = model.Image,
            ImageAlt = model.ImageAlt,
            PublicationDate = model.PublicationDate,
            Author = model.Author,
            CategoryId = 1,
            Rate = model.Rate
        };
        private static PostViewModel GetModel(BasePost post)
        {
            post ??= new BasePost(); post.Category.CategoryName ??= new CategoryViewModel(post.CategoryId).Category;

            PostViewModel model = new()
            {
                Id = post.Id,
                Title = post.Title,
                SubTitle = post.SubTitle,
                Body = post.Body,
                Image = post.Image,
                ImageAlt = post.ImageAlt,
                PublicationDate = post.PublicationDate,
                Author = post.Author,
                Category = post.Category.CategoryName,
                CategoryId = post.CategoryId,
                Rate = post.Rate
            };

            return model;
        }
    }
}
