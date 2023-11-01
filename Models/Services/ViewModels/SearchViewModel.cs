using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    public class SearchViewModel
    {
        public string Search { get; set; }
        public string Action { get; set; }
        public List<PostViewModel> SearchList { get; set; }
        public List<int> PaginationData { get; set; }

        public SearchViewModel()
        {
            Search = "";
            Action = "Index";
            SearchList = new();
            PaginationData = new();
        }
    }
}
