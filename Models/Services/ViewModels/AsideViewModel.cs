using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    public class AsideViewModel
    {
        public List<List<PostViewModel>> asidesList { get; set; }
        public string asideTitle { get; set; }
        public List<string> asideTitles { get; set; }
        public SearchViewModel SearchData { get; set; }
        public AsideViewModel()
        {
            asidesList = new();
            asideTitles = new List<string>();
            asideTitle = "";
            SearchData = new();
        }
    }
}
