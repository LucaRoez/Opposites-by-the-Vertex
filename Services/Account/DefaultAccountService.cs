using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;

namespace Opuestos_por_el_Vertice.Services.Account
{
    public class DefaultAccountService : IAccountService
    {
        private readonly IRepository _repository;
        public DefaultAccountService(IRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> RegisterUser(UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LoginUser(string userName, string password, string? email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> RestoreUser(UserViewModel newUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConfirmUser(string token)
        {
            throw new NotImplementedException();
        }
    }
}
