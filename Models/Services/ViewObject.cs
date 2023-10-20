using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services
{
    public class ViewObject
    {
        public PostViewModel CurrentPost { get; set; }
        public List<PostViewModel> CurrentPostList { get; set; }
        public ViewObject()
        {
            CurrentPost = new();
            CurrentPostList = new();
        }
    }
}
