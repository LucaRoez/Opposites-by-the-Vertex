using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    /*
     * Because of my personal View Envelopment Service, it need to centralize all the View final data here, in this final view model, that
     *  gets the current post or post collection, there into the ObjectClass attribute, the web site name and his idemtifier, into the Kind
     *  attribute.
    */

    public class ViewKindViewModel
    {
        public ViewObject ObjectClass { get; set; }
        public string Kind { get; set; }
        public string WebTitle { get; set; }
        public List<string> ExtraInfo { get; set; }
        public int CurrentPage { get; set; }
        public AdminPackage AdminInfo { get; set; }
        public List<PostViewModel> Search { get; set; }
        public ViewKindViewModel()
        {
            ObjectClass = new();
            Kind = "";
            WebTitle = "";
            ExtraInfo = new ();
            CurrentPage = 0;
            AdminInfo = new();
            Search = new();
        }
    }
}
