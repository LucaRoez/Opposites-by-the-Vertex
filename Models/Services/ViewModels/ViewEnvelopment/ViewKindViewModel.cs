using Opuestos_por_el_Vertice.Models.Services.ViewEnvelopment;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels.ViewEnvelopment
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
        public string PageTitle { get; set; }
        public HeroViewModel HeroData { get; set; }
        public AdminPackage AdminInfo { get; set; }
        public SearchViewModel SearchData { get; set; }
        public AsideViewModel AsideData { get; set; }

        public ViewKindViewModel()
        {
            ObjectsClass = new(new(), new());
            Kind = "Home";
            PageTitle = "The Next Best Metal Page Ever!";
            HeroData = new(null, null, null, null, null);
            AdminInfo = new(null, null);
            SearchData = new();
            AsideData = new(null, null);
        }

        public ViewKindViewModel(
            string? kind, string? title,
            List<PostViewModel> posts, PostViewModel? post,
            HeroViewModel hero, AsideViewModel aside,
            SearchViewModel? search, AdminPackage admin
            )
        {
            ObjectsClass = new(posts ?? new(), post ?? new());
            Kind = kind ?? "";
            PageTitle = title ?? "";
            HeroData = hero;
            AdminInfo = admin;
            SearchData = search ?? new();
            AsideData = aside;
        }
    }
}
