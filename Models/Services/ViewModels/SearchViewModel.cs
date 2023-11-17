using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    public class SearchViewModel
    {
        public string Search { get; set; }
        public string Action { get; set; }
        public List<PostViewModel> SearchList { get; set; }
        public List<int> PaginationData { get; set; }

        public SearchViewModel(string? search, string? action, List<PostViewModel>? searchList, List<int>? pagData)
        {
            Search = search ?? "";
            Action = action ?? "Index";
            SearchList = searchList ?? new();
            PaginationData = pagData ?? new() { 0, 1 };
        }
    }
}
