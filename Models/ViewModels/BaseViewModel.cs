using Opuestos_por_el_Vertice.Models.Services;

namespace Opuestos_por_el_Vertice.Models.ViewModels
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }
        public BaseViewModel()
        {
            Id = 0;
        }
    }
}
