using Opuestos_por_el_Vertice.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels
{
    /*
     * This model isolate the correct view model from his own layer, to facilitate their handling.
    */

    public abstract class PostingSeed : BaseViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        [DisplayName("Publication Title")]
        public string Title { get; set; }
        [StringLength(120, MinimumLength = 6)]
        [DisplayName("Subtitle")]
        public string SubTitle { get; set; }
        [DisplayName("Publication Body")]
        public string Body { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [DisplayName("Hero Image")]
        public string Image { get; set; }
        [DisplayName("Hero Image Description")]
        public string ImageAlt { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Post Date")]
        public DateTime PublicationDate { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        [DisplayName("Publication Author/Writer")]
        public string Author { get; set; }
        [DisplayName("Publication Category")]
        public string Category { get; set; }
        [Required]
        [DisplayName("Publication Category")]
        public int CategoryId { get; set; }
        [DisplayName("Post Rating")]
        public int Rate { get; set; }

        public PostingSeed()
        {
            Title = "";
            SubTitle = "";
            Body = "";
            Image = "";
            ImageAlt = "";
            PublicationDate = new();
            Author = "";
            Category = "";
            CategoryId = 0;
            Rate = 0;
        }
    }
}
