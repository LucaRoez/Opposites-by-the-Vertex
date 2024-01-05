using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Models.Services.ViewEnvelopmentSystem;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IControllerCore _envelopment;

        public SearchController(ILogger<SearchController> logger, IControllerCore envelopment)
        {
            _logger = logger;
            _envelopment = envelopment;
        }
                
        public  IActionResult Index(string search, string adminOrder = "", int page = 1, string controllerInput = "IndexSearch") => View(_envelopment.GetViewEnvelopment(controllerInput, page, search, ""));
                
        public  IActionResult Events(string search, int page = 1, string controllerInput = "EventsSearch") => View(_envelopment.GetViewEnvelopment(controllerInput, page, search, "Event"));
                
        public  IActionResult News(string search, int page = 1, string controllerInput = "NewsSearch") => View(_envelopment.GetViewEnvelopment(controllerInput, page, search, "New"));
                
        public  IActionResult Artists(string search, int page = 1, string controllerInput = "ArtistsSearch") => View(_envelopment.GetViewEnvelopment(controllerInput, page, search, "Artist"));
                
        public  IActionResult Albums(string search, int page = 1, string controllerInput = "AlbumsSearch") => View(_envelopment.GetViewEnvelopment(controllerInput, page, search, "Album"));
                
        public  IActionResult Genres(string search, int page = 1, string controllerInput = "GenresSearch") => View(_envelopment.GetViewEnvelopment(controllerInput, page, search, "Genre"));
    }
}
