namespace Opuestos_por_el_Vertice.Data.Entities
{
    public class BasePost : IPost, IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Rate { get; set; }
    }
}
