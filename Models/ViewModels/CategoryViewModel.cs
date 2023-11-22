namespace Opuestos_por_el_Vertice.Models.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public string Category { get; set; }
        public CategoryViewModel(int id)
        {
            switch (id)
            {
                case 2: Category = "Event"; Id = id; break;
                case 3: Category = "Artist"; Id = id; break;
                case 4: Category = "Album"; Id = id; break;
                case 5: Category = "Genre"; Id = id; break;
                case 1: Category = "New"; Id = id; break;
                default: Category = "Genre"; Id = 5; break;
            }
        }
    }
}
