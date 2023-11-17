using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.DataTranfer;

namespace Opuestos_por_el_Vertice.Services.AdminManager
{
    public class DefaultAdminManager : IAdminManager
    {
        private readonly IRepository _repository;
        public DefaultAdminManager(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateNewPost(PostViewModel model)
        {
            model.Body ??= ""; model.Category = GetCategoryName(model.CategoryId);
            await _repository.Create<BasePost>(DataConverter.GetModelData(ParsePostBody(model)));
        }

        public async Task UpdatePost(int id, PostViewModel model, string oldCategory)
        {
            int categoryId = model.CategoryId;
            model.Body ??= ""; model.Category = GetCategoryName(categoryId);
            model = ParsePostBody(model);
            BasePost Post = await _repository.DetailOne(oldCategory, id);

            if (categoryId != Post.CategoryId)
            {
                model.PublicationDate = Post.PublicationDate;
                model.Rate = Post.Rate;

                await _repository.Remove(Post);
                await _repository.Create<BasePost>(DataConverter.GetModelData(ParsePostBody(model)));
            }
            else
            {
                Post.Title = model.Title;
                Post.SubTitle = model.SubTitle;
                Post.Body = model.Body;
                Post.Image = model.Image;
                Post.ImageAlt = model.ImageAlt;
                Post.Author = model.Author;
                Post.CategoryId = model.CategoryId;

                await _repository.Update(Post);
            }
        }

        public async Task RemovePost(int id, string category) => await _repository.Remove(await _repository.DetailOne(category, id));

        public async Task RemoveAll(string identifier) => await _repository.RemoveAll(identifier);

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
            string category = Categories.FirstOrDefault(c => c.Id == id)?.CategoryName ?? "Default";

            return category;
        }
    }
}
