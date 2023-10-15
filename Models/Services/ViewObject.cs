namespace Opuestos_por_el_Vertice.Models.Services
{
    public abstract class ViewObject
    {
        int Id { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        string Body { get; set; }
        string Image { get; set; }
        DateTime PublicationDate { get; set; }
        string Author { get; set; }
        int GenreClass { get; set; }
    }
}
