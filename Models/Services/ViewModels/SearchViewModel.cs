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
            : this("", "Index", new List<PostViewModel>(), new List<int>() { 0, 1 })
        {
        }
        public SearchViewModel(string? search, string? action, List<PostViewModel>? searchList, List<int>? pagData)
        {
            Search = search ?? "";
            Action = action+"s" ?? "Index";
            SearchList = searchList ?? new List<PostViewModel>();
            PaginationData = pagData ?? new List<int>() { 0, 1 };
        }
    }
}
