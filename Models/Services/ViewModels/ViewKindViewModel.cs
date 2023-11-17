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
        public ViewObjects ObjectsClass { get; set; }
        public string Kind { get; set; }
        public string WebTitle { get; set; }
        public HeroViewModel HeroData { get; set; }
        public int CurrentPage { get; set; }
        public AdminPackage AdminInfo { get; set; }
        public SearchViewModel SearchData { get; set; }
        public AsideViewModel AsideData { get; set; }
        public ViewKindViewModel(
            List<PostViewModel> posts, PostViewModel? post,
            HeroViewModel hero, AsideViewModel aside,
            SearchViewModel? search, AdminPackage admin
            )
        {
            ObjectsClass = new(posts?? new(), post?? new());
            Kind = "";
            WebTitle = "";
            HeroData = hero;
            CurrentPage = 1;
            AdminInfo = admin;
            SearchData = search ?? new("", "", new(), new());
            AsideData = aside;
        }
    }
}
