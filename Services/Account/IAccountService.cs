using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;

namespace Opuestos_por_el_Vertice.Services.Account
{
    public interface IAccountService
    {
        Task<string> RegisterUser(UserViewModel user);
        Task<string> LoginUser(string email, string password);
        Task<UserViewModel?> GetUser(string email);
        Task<bool> ConfirmUser(string token);
        Task<string> ReestablishUser(string token, string password);
        Task<UserViewModel> UpdateUser(UserViewModel newUser);
        Task<bool> DeleteUser(int id);
    }
}
