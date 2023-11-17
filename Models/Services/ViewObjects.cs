using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services
{
    public class ViewObjects
    {
        public PostViewModel SelectedPost { get; set; }
        public List<PostViewModel> PresentedPostsList { get; set; }
        public ViewObjects(List<PostViewModel> posts, PostViewModel post)
        {
            SelectedPost = post;
            PresentedPostsList = posts;
        }
    }
}
