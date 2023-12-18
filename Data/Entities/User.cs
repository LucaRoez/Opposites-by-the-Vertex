using System.ComponentModel.DataAnnotations;

namespace Opuestos_por_el_Vertice.Data.Entities
{
    public class User : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 2)]
        public string UserName { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string? FirstName { get; set; }
        [StringLength(30, MinimumLength = 2)]
        public string? LastName { get; set; }
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(2000)]
        public string Password { get; set; }
        [StringLength(100, MinimumLength = 4)]
        [Phone]
        public string? Phone { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsAccountRestored { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        [StringLength(500)]
        public string Token { get; set; }
    }
}
