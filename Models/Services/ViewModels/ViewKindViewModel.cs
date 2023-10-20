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
        public ViewKindViewModel()
        {
            ObjectClass = new();
            Kind = "";
            WebTitle = "";
        }
    }
}
