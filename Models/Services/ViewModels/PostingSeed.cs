using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    public abstract class PostingSeed : BaseViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Author { get; set; }
        public int GenreClass { get; set; }
        public int Rate { get; set; }
        public PostingSeed()
        {
            Title = "";
            SubTitle = "";
            Body = "";
            Image = "";
            PublicationDate = new();
            Author = "";
            GenreClass = 0;
            Rate = 0;
        }
    }
}
