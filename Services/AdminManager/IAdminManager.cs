using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Services.AdminManager
{
    public interface IAdminManager
    {
        Task CreateNewPost(PostViewModel post);
        Task RemovePost(int id, string category);
        Task UpdatePost(int id, PostViewModel model, string category);
        Task RemoveAll(string identifier);
    }
}
