using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Services.Data_Tranfer
{
    /*
     * This Service is for convert the Data Base info into a view model one, using different methods in both directions.
    */

    public interface IDataTruck
    {
        BasePost GetPostData(PostViewModel model);
        PostViewModel GetPostModel(BasePost post);
        List<BasePost> GetAllPostDatas(List<PostViewModel> models);
        List<PostViewModel> GetAllPostModels(List<BasePost> posts);
    }
}
