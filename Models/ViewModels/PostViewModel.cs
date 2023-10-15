using Opuestos_por_el_Vertice.Models.Services;

namespace Opuestos_por_el_Vertice.Models.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Author { get; set; }
        public int GenreClass { get; set; }
    }
}
