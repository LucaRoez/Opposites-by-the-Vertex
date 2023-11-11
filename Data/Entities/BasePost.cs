using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Opuestos_por_el_Vertice.Data.Entities
{
    public class BasePost : IPost, IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Title { get; set; }
        [Required]
        [StringLength(120, MinimumLength = 6)]
        public string SubTitle { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(4000)]
        public string Body { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [StringLength(255, MinimumLength = 9)]
        public string Image { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string ImageAlt { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Author { get; set; }
        [Required]
        [Range(1,5)]
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required]
        public int Rate { get; set; }
    }
}
