using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System;
using Opuestos_por_el_Vertice.Models.ViewModels;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;
        private readonly IViewEnvelopment _envelopment;

        public SearchController(ILogger<SearchController> logger, IViewEnvelopment envelopment)
        {
            _logger = logger;
            _envelopment = envelopment;
        }

        public  IActionResult Index(SearchViewModel searchInfo, string adminOrder = "", int page = 1, string controllerInput = "IndexSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, searchInfo, adminOrder));

        public  IActionResult Events(SearchViewModel searchInfo, int page = 1, string controllerInput = "EventsSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, searchInfo, "Event"));

        public  IActionResult News(SearchViewModel searchInfo, int page = 1, string controllerInput = "NewsSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, searchInfo, "New"));

        public  IActionResult Artists(SearchViewModel searchInfo, int page = 1, string controllerInput = "ArtistsSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, searchInfo, "Artist"));

        public  IActionResult Albums(SearchViewModel searchInfo, int page = 1, string controllerInput = "AlbumsSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, searchInfo, "Album"));

        public  IActionResult Genres(SearchViewModel searchInfo, int page = 1, string controllerInput = "GenresSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, searchInfo, "Genre"));
    }
}
