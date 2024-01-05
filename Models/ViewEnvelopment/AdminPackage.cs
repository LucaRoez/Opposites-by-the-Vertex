using Opuestos_por_el_Vertice.Models.Services.ViewModels.ViewEnvelopment;

namespace Opuestos_por_el_Vertice.Models.Services.ViewEnvelopment
{
    public class AdminPackage
    {
        public string AdminMessage { get; set; }
        public CategoriesViewModel Categories { get; set; }
        public int CategoryId { get; set; }

        public AdminPackage(string? adminMessage, int? categoryId)
        {
            AdminMessage = adminMessage ?? "";
            Categories = new();
            CategoryId = categoryId ?? 0;
        }
    }
}
