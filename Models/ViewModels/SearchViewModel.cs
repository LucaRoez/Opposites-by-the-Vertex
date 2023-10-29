namespace Opuestos_por_el_Vertice.Models.ViewModels
{
    public class SearchViewModel
    {
        public string Search { get; set; }
        public string Action { get; set; }

        public SearchViewModel()
        {
            Search = "";
            Action = "IndexSearch";
        }
    }
}
