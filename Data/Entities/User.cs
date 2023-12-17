using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Opuestos_por_el_Vertice.Data.Entities
{
    public class User : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string UserName { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(2000)]
        public string Password { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public bool IsEmailConfirmed { get; set; }
        [Required]
        public bool IsAccountRestored { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        [Required]
        [StringLength(500)]
        public string Token { get; set; }
    }
}
