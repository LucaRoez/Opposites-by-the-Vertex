using Opuestos_por_el_Vertice.Data.Entities;

namespace Opuestos_por_el_Vertice.Data
{
    /*
     * This is a traditional Repository desing pattern, where the interaction with the Data Base is isolated from Services and Controllers. 
    */

    public interface IRepository
    {
        Task Create<TEntity>(BasePost post) where TEntity : BasePost;
        Task Remove(BasePost post);
        Task Update(BasePost post);
        Task RemoveAll(string identifier);
        Task<BasePost> DetailOne(string category, int id);
        List<BasePost> DetailAll(string category);
        List<Category> GetCategories();
        Task UnbendDb();
        Task Register(User user);
        Task<User?> GetUser(string input);
        bool ConfirmUser(string token);
        Task<User?> GetUserByToken(string token);
        Task UpdateUser(User user);
    }
}
