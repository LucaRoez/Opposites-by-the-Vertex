using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace Opuestos_por_el_Vertice.Services.Data_Tranfer
{
    public class DataTruck : IDataTruck
    {
        private readonly IRepository _repository;
        public DataTruck(IRepository repository)
        {
            _repository = repository;
        }
        public Post GetPostData(PostViewModel model)
        {
            Post post = new()
            {
                Title = model.Title,
                SubTitle = model.SubTitle,
                Body = model.Body,
                Image = model.Image,
                PublicationDate = model.PublicationDate,
                Author = model.Author,
                GenreClass = model.GenreClass,
                Rate = model.Rate
            };

            return post;
        }

        public List<Post> GetAllPostData(List<PostViewModel> models)
        {
            List<Post> posts = new();
            foreach (var model in models) { posts.Add(GetPostData(model)); }

            return posts;
        }

        public PostViewModel GetPostModel(Post post)
        {
            PostViewModel model = new()
            {
                Title = post.Title,
                SubTitle = post.SubTitle,
                Body = post.Body,
                Image = post.Image,
                PublicationDate = post.PublicationDate,
                Author = post.Author,
                GenreClass = post.GenreClass,
                Rate = post.Rate
            };

            return model;
        }

        public List<PostViewModel> GetAllPostModels(List<Post> posts)
        {
            List<PostViewModel> models = new();
            foreach (var post in posts) { models.Add(GetPostModel(post)); }

            return models;
        }
    }
}
