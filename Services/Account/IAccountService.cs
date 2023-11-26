using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;

namespace Opuestos_por_el_Vertice.Services.Account
{
    public interface IAccountService
    {
        Task<string> RegisterUser(UserViewModel user);
        string LoginUser(string email, string password);
        UserViewModel GetUser(string email);
        bool ConfirmUser(string token);
        string ReestablishUser(string token, string password);
        Task<UserViewModel> UpdateUser(UserViewModel newUser);
        Task<bool> DeleteUser(int id);
    }
}
