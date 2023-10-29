using Microsoft.Extensions.Hosting;
using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.Data_Tranfer;

namespace Opuestos_por_el_Vertice.Services.AdminManager
{
    public class DefaultAdminManager : IAdminManager
    {
        private readonly IRepository _repository;
        private readonly IDataTruck _dataTruck;
        public DefaultAdminManager(IRepository repository, IDataTruck dataTruck)
        {
            _repository = repository;
            _dataTruck = dataTruck;
        }

        public async Task CreateNewPost(PostViewModel model)
        {
            model = CheckNulls(model); model.Category = GetCategoryName(model.CategoryId);
            BasePost Post = _dataTruck.GetPostData(ParsePostBody(model));
            await _repository.Create(Post);
        }

        public async Task RemovePost(int id, string category)
        {
            var Post = await _repository.DetailOne(category, id);
            await _repository.Remove(Post);
        }

        public async Task UpdatePost(int id, PostViewModel model, string category)
        {
            model = ParsePostBody(model);

            BasePost Post = await _repository.DetailOne(category, id);
            {
                Post.Title = model.Title;
                Post.SubTitle = model.SubTitle;
                Post.Body = model.Body;
                Post.Image = model.Image;
                Post.ImageAlt = model.ImageAlt;
                Post.Author = model.Author;
                Post.CategoryId = model.CategoryId;
            }

            await _repository.Update(Post);
        }

        private PostViewModel CheckNulls(PostViewModel post)
        {
            if (post.Body == null) { post.Body = ""; }

            return post;
        }
        private PostViewModel ParsePostBody(PostViewModel post)
        {
            var body = post.Body;
            body = "<p>" + body.Replace("<..>", "</p><p>")
                .Replace("<title>", "<h3>").Replace("<litle>", "<h5>")
                .Replace("</title>", "</h3>").Replace("</litle>", "</h5>");
            post.Body = body.Insert(body.Length, "</p>");

            return post;
        }
        private string GetCategoryName(int id)
        {
            List<Category> Categories = _repository.GetCategories();
            string category = Categories.FirstOrDefault(c => c.Id == id).CategoryName;

            return category;
        }
    }
}
