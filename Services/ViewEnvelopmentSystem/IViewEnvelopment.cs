using Opuestos_por_el_Vertice.Models.Services.ViewModels.ViewEnvelopment;

namespace Opuestos_por_el_Vertice.Models.Services.ViewEnvelopmentSystem
{
    /*
     * This Service is for the View data envelopment, so the Controller sends the web site where it comes from, therefore it communicates with
     *  the Repository to catch the data, where each data iteration depends on the web site info. For example, if the web site is the Home, then
     *  it will look for all of the post published, according to all data categories for displaying into the final View.
    */

    public interface IViewEnvelopment
    {
        Task<ViewKindViewModel> GetViewEnvelopment(string controllerInput);
        Task<ViewKindViewModel> GetViewEnvelopment(string controllerInput, int id, string extraData);
        ViewKindViewModel GetViewEnvelopment(string controllerInput, int page, string search, string postCategory);
    }
}
