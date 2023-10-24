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

        public async Task CreateNewPost(PostViewModel post) => await _repository.Create(_dataTruck.GetPostData(ParsePostBody(post)));
        private PostViewModel ParsePostBody(PostViewModel post)
        {
            var body = post.Body;
            body = "<p>" + body.Replace("<..>", "</p><p>")
                .Replace("<title>", "<h3>").Replace("<litle>", "<h5>")
                .Replace("</title>", "</h3>").Replace("</litle>", "</h5>");
            post.Body = body.Insert(body.Length, "</p>");

            return post;
        }

        public async Task RemovePost(int id, string category) => await _repository.Remove(_repository.DetailAll(category).Find(p => p.Id == id));

        public async Task UpdatePost(int id, string category) => await _repository.Update(_repository.DetailAll(category).Find(p => p.Id == id));
    }
}
