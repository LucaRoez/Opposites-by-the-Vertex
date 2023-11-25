namespace Opuestos_por_el_Vertice.Models.Services.EmailSender
{
    public class EmailBase
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
