using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    public class CategoriesViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public CategoriesViewModel()
        {
            Categories = new List<CategoryViewModel>();
            for (int i = 1; i <= 5; i++) { Categories.Add(new CategoryViewModel(i)); }
        }
    }
}
