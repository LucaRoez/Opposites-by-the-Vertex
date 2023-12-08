using Opuestos_por_el_Vertice.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels.Account
{
    public class UserViewModel : BaseViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string UserName { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        [PasswordPropertyText]
        public string ConfirmationPassword { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsAccountRestored { get; set; }
        public DateTime Created { get; set; }
        public string Token { get; set; }
    }
}
