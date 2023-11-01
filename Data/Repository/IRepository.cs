using Opuestos_por_el_Vertice.Data.Entities;

namespace Opuestos_por_el_Vertice.Data.Repository
{
    /*
     * This is a traditional Repository desing pattern, where the interaction with the Data Base is isolated from Services and Controllers. 
    */

    public interface IRepository
    {
        Task Create(BasePost post, string category);
        Task Remove(BasePost post);
        Task Update(BasePost post);
        Task<BasePost> DetailOne(string category,int id);
        List<BasePost> DetailAll(string category);
        List<Category> GetCategories();
        Task ArrangeDb();
    }
}
