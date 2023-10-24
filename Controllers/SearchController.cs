using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System;

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

        public  IActionResult Index(string adminOrder = "", int page = 1, string controllerInput = "IndexSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, adminOrder));

        public  IActionResult Events(int page = 1, string controllerInput = "EventsSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, "Event"));

        public  IActionResult News(int page = 1, string controllerInput = "NewsSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, "New"));

        public  IActionResult Artists(int page = 1, string controllerInput = "ArtistsSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, "Artist"));

        public  IActionResult Albums(int page = 1, string controllerInput = "AlbumsSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, "Album"));

        public  IActionResult Genres(int page = 1, string controllerInput = "GenresSearch") => View( _envelopment.GetSearchEnvelopment(controllerInput, page, "Genre"));
    }
}
