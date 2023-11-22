using Microsoft.IdentityModel.Tokens;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels.ViewEnvelopment
{
    public class SearchViewModel
    {
        public string Search { get; set; }
        public string Action { get; set; }
        public List<PostViewModel> SearchList { get; set; }
        public List<int> PaginationData { get; set; }
        public int CurrentPage { get; set; }

        public SearchViewModel()
            : this("", "Index", new List<PostViewModel>(), new List<int>() { 0, 1 }, 1)
        {
        }
        public SearchViewModel(string? search, string? action, List<PostViewModel>? searchList, List<int>? pagData, int? currentPage)
        {
            Search = search ?? "";
            Action = action != null && action != "Index" ? action + "s" : "Index";
            SearchList = searchList ?? new();
            PaginationData = pagData ?? new() { 0, 1 };
            CurrentPage = currentPage ?? 1;
        }
    }
}
