using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;
using Opuestos_por_el_Vertice.Services.EmailSender;

namespace Opuestos_por_el_Vertice.Services.Account
{
    public class DefaultAccountService : IAccountService
    {
        private readonly IRepository _repository;
        public DefaultAccountService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> RegisterUser(UserViewModel user)
        {
            if (user.Password == user.ConfirmationPassword)
            {
                try
                {
                    User User = new()
                    {
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = EmailSenderUtilities.ConvertSHA256(user.Password),
                        Phone = user.Phone,
                        IsEmailConfirmed = user.IsEmailConfirmed,
                        IsAccountRestored = user.IsAccountRestored,
                        Created = user.Created,
                        Token = user.Token
                    };

                    await _repository.Register(User);
                    return "true";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else { return "Passwords Unmatched"; }
        }

        public string LoginUser(string email, string password)
        {
            User? user = _repository.GetUser(email);
            if (user == null) { return "User doesn't exist"; }
            if (user.Password != password) { return "Password didn't match"; }
            return "User logged successfully";
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUser(string email)
        {
            User? User = _repository.GetUser(email);
            UserViewModel user = new()
            {
                Id = User.Id,
                UserName = User.UserName,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Email = User.Email,
                Password = User.Password,
                Phone = User.Phone,
                IsEmailConfirmed = User.IsEmailConfirmed,
                IsAccountRestored = User.IsAccountRestored,
                Created = User.Created,
                Token = User.Token
            };

            return user;
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
