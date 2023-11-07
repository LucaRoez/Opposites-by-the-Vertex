using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    public class AsideViewModel
    {
        public List<List<PostViewModel>> AsidesList { get; set; }
        public string AsideTitle { get; set; }
        public List<string> AsideTitles { get; set; }
        public SearchViewModel SearchData { get; set; }

        public AsideViewModel()
        {
            AsidesList = new();
            AsideTitles = new List<string>();
            AsideTitle = "";
            SearchData = new();
        }
    }
}
