using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;

namespace Opuestos_por_el_Vertice.Services.Account
{
    public interface IAccountService
    {
        Task<string> RegisterUser(UserViewModel user);
        string LoginUser(string email, string password);
        UserViewModel GetUser(string email);
        Task<bool> DeleteUser(int id);
        Task<UserViewModel> RestoreUser(UserViewModel newUser);
        Task<bool> ConfirmUser(string token);
    }
}
