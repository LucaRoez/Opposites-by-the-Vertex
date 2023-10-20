using Opuestos_por_el_Vertice.Data.Entities;

namespace Opuestos_por_el_Vertice.Data.Repository
{
    public interface IRepository
    {
        Task Create(List<Post> posts);
        Task Remove(List<Post> posts);
        Task Update(List<Post> posts);
        Task<Post> DetailOne(int id);
        List<Post> DetailAll();

    }
}
