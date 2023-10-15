namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    public class ViewClassViewModel
    {
        public ViewObject ObjectClass { get; set; }
        public string Class { get; set; }
        public string WebTitle { get; set; }
        public ViewClassViewModel()
        {
            ObjectClass = new();
            Class = "";
            WebTitle = "";
        }
    }
}
