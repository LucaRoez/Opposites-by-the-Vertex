using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;

namespace Opuestos_por_el_Vertice.Models.Services.ViewEnvelopment
{
    public class AccountPackage
    {
        public UserViewModel User { get; set; }
        public string AccountMessage { get; set; }

        public AccountPackage()
        {
            User = null;
            AccountMessage = "";
        }
        public AccountPackage(UserViewModel? user, string? accountMessage)
        {
            User = user ?? new();
            AccountMessage = accountMessage ?? "";    
        }
    }
}
