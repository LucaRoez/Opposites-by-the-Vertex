using Microsoft.AspNetCore.Hosting;
using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;
using Opuestos_por_el_Vertice.Services.DataTranfer;
using Opuestos_por_el_Vertice.Services.EmailSender;
using Org.BouncyCastle.Asn1.Ocsp;
using System;

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
            if (_repository.GetUser(user.Email) == null)
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
                return "Passwords Unmatched";
            }
            else
            {
                return "The user is already registered in our data base";
            }
        }

        public string LoginUser(string input, string password)
        {
            User? user = _repository.GetUser(input);
            if (user == null) { return "User doesn't exist"; }
            else if (user.Password != password) { return "Password didn't match"; }
            else if (user.IsEmailConfirmed!) { return "The confirmation email was sent, please confirm your account first coming into your email inboxand lock for our email"; }
            else if (user.IsAccountRestored) { return "Your account was requested to be re-established and wasn't confirmed yet, please go to your email inbox to confirm your account restored first"; }
            return "User logged successfully";
        }

        public UserViewModel GetUser(string email)
        {
            User? User = _repository.GetUser(email);

            return DataConverter.GetUserModel(User);
        }

        public bool ConfirmUser(string token)
        {
            if (_repository.ConfirmUser(token))
            {
                User user = _repository.GetUserByToken(token);
                user.IsEmailConfirmed = true;
                _repository.UpdateUser(user);

                return true;
            }
            else { return false; }
        }

        public string ReestablishUser(string token, string password)
        {
            User user = _repository.GetUserByToken(token);
            if (user == null) { return "The user doesn't exist"; }
            else
            {
                user.Password = password;
                _repository.UpdateUser(user);
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
