using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Models.Services.ViewModels.ViewEnvelopment
{
    public class HeroViewModel
    {
        public int ImagesAmount { get; set; }
        public List<string> ImageSources { get; set; }
        public List<string> ImageAltSources { get; set; }
        public List<string> Titles { get; set; }
        public List<string> SubTitles { get; set; }

        public HeroViewModel(int? imgAmount, List<string>? imgSrc, List<string>? imgAlt, List<string>? titles, List<string>? subs)
        {
            ImagesAmount = imgAmount ?? 1;
            ImageSources = imgSrc ?? new();
            ImageAltSources = imgAlt ?? new();
            Titles = titles ?? new();
            SubTitles = subs ?? new();
        }
    }
}
