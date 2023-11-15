using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Services.DataTranfer.DataTruck
{
    public class DataTruck : IDataTruck
    {
        private BasePost? Post { get; set; }

        public BasePost? GetPostData(PostViewModel model)
        {
            if (model.Category == "Artist")
            {
                Artist post = new()
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
                }; Post = post;
            }
            else if (model.Category == "Album")
            {
                Album post = new()
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
                }; Post = post;
            }
            else if (model.Category == "Genre")
            {
                Genre post = new()
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
                }; Post = post;
            }
            else if (model.Category == "Event")
            {
                Event post = new()
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
                }; Post = post;
            }
            else if (model.Category == "New")
            {
                New post = new()
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
                }; Post = post;
            }
            else
            {
                New post = new()
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
                }; Post = post;
            }

            return Post;
        }

        public List<BasePost> GetAllPostDatas(List<PostViewModel> models)
        {
            List<BasePost> posts = new();
            foreach (var model in models) { posts.Add(GetPostData(model)); }

            return posts;
        }

        public PostViewModel GetPostModel(BasePost post)
        {
            if (post == null) { return new PostViewModel(); }

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

        public List<PostViewModel> GetAllPostModels(List<BasePost> posts)
        {
            List<PostViewModel> models = new();
            foreach (var post in posts) { models.Add(GetPostModel(post)); }

            return models;
        }
    }
}
