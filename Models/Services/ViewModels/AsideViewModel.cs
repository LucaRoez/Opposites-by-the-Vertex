using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    public class AsideViewModel
    {
        public List<List<PostViewModel>> AsidesList { get; set; }
        public string AsideTitle { get; set; }
        public static string[] AsideTitles { get; set; } = new[]
            {
                "Artist or Bands More Popular",
                "Shows and Concerts More Popular",
                "Relevant Metal News",
                "Albums More Popular",
                "Genres or Subgenres More Popular"
            };
        public SearchViewModel SearchData { get; set; }

        public AsideViewModel(string title, SearchViewModel search)
        {
            AsidesList = new();
            AsideTitle = title ?? "";
            SearchData = search ?? new();
        }
    }
}
