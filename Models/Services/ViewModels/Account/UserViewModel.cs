using Opuestos_por_el_Vertice.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels.Account
{
    public class UserViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "An User Name is required")]
        [StringLength(60, MinimumLength = 2)]
        public string UserName { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "An Email is required")]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Password is required")]
        [StringLength(20, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#]).{8,20}$",
            ErrorMessage = "Must contain at least one lower case, one upper case, one number, and one special character")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please repeat your Password")]
        public string ConfirmationPassword { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Phone]
        public string Phone { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsAccountRestored { get; set; }
        public DateTime Created { get; set; }
        public string Token { get; set; }
    }
}
