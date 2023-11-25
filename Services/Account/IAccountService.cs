using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;

namespace Opuestos_por_el_Vertice.Services.Account
{
    public interface IAccountService
    {
        Task<bool> RegisterUser(UserViewModel user);
        Task<bool> LoginUser(string userName, string password, string? email);
        Task<bool> GetUser(string email);
        Task<bool> DeleteUser(int id);
        Task<UserViewModel> RestoreUser(UserViewModel newUser);
        Task<bool> ConfirmUser(string token);
    }
}
