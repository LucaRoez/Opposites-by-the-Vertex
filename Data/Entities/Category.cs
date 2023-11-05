using System.ComponentModel.DataAnnotations;

namespace Opuestos_por_el_Vertice.Data.Entities
{
    public class Category : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
