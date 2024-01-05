namespace Opuestos_por_el_Vertice.Data.Entities
{
    public interface IPost
    {
        string Title { get; set; }
        string SubTitle { get; set; }
        string Body { get; set; }
        string Image { get; set; }
        string ImageAlt { get; set; }
        DateTime PublicationDate { get; set; }
        string Author { get; set; }
        Category Category { get; set; }
        int Rate { get; set; }
    }
}
