using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels.Account
{
    public class UserViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
        public string Phone { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsAccountRestored { get; set; }
        public DateTime Created { get; set; }
        public string Token { get; set; }

        public UserViewModel()
        {
            IsEmailConfirmed = false;
            IsAccountRestored = false;
            Created = DateTime.Now;
        }
    }
}
