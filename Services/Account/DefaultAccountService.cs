using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;
using Opuestos_por_el_Vertice.Services.DataTranfer;
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
            if (await _repository.GetUser(user.Email) == null)
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
                        IsEmailConfirmed = false,
                        IsAccountRestored = false,
                        Created = DateTime.Now,
                        Token = EmailSenderUtilities.CreateToken()
                    };
                    await _repository.Register(User);
                    return "true";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (user.Password != user.ConfirmationPassword)
            {
                return "Unmatched entered passwords";
            }
            else
            {
                return "The user is already registered in our data base";
            }
        }

        public async Task<string> LoginUser(string input, string password)
        {
            password = EmailSenderUtilities.ConvertSHA256(password);
            User? user = await _repository.GetUser(input);
            if (user == null) { return "Searched user doesn't exist"; }
            else if (user.Password != password) { return "Incorrect password entered"; }
            else if (user.IsEmailConfirmed!) { return @"The confirmation email was sent, please confirm your account first coming " +
                    "into your email inboxand lock for our email"; }
            else if (user.IsAccountRestored) { return @"Your account was requested to be re-established and wasn't confirmed yet, " +
                    "please go to your email inbox to confirm your account restored first"; }
            return "User logged successfully";
        }

        public async Task<UserViewModel?> GetUser(string email)
        {
            User? User = await _repository.GetUser(email);

            return DataConverter.GetUserModel(User);
        }

        public async Task<bool> ConfirmUser(string token)
        {
            if (_repository.ConfirmUser(token))
            {
                User? user = await _repository.GetUserByToken(token);
                user.IsEmailConfirmed = true;
                await _repository.UpdateUser(user);

                return true;
            }
            else { return false; }
        }

        public async Task<string> ReestablishUser(string token, string password)
        {
            User? user = await _repository.GetUserByToken(token);
            if (user == null) { return "The user doesn't exist"; }
            else
            {
                user.Password = password;
                user.IsAccountRestored = false;
                await _repository.UpdateUser(user);
            }
            return "The user was re-established successfully";
        }

        public Task<UserViewModel> UpdateUser(UserViewModel newUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
