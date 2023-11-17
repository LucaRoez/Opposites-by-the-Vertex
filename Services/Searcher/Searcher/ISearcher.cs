using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Services.Searcher.Searcher
{
    public interface ISearcher
    {
        Task<PostViewModel> GetViewModel(int id, string postCategory);
        List<PostViewModel> GetViewModelList(string[] schemas, int iterations);
        List<PostViewModel> GetSearch(string search, string category);
        List<int> GetPaginationData(int totalPosts);
        AsideViewModel GetAsideSearch(List<PostViewModel> pageList, string pageKind, PostViewModel model, SearchViewModel search);
    }
}
