using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Services.Data_Tranfer
{
    public interface IDataTruck
    {
        Post GetPostData(PostViewModel model);
        PostViewModel GetPostModel(Post post);
        List<Post> GetAllPostData(List<PostViewModel> models);
        List<PostViewModel> GetAllPostModels(List<Post> posts);
    }
}
