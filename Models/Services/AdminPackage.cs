using Opuestos_por_el_Vertice.Models.Services.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services
{
    public class AdminPackage
    {
        public string AdminMessage { get; set; }
        public CategoriesViewModel Categories { get; set; }
        public int CategoryId { get; set; }

        public AdminPackage()
        {
            AdminMessage = "";
            Categories = new();
            CategoryId = 0;
        }
    }
}
