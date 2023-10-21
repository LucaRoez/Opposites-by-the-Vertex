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

        public IActionResult Index(string controllerInput = "IndexSearch") => View(_envelopment.GetEnvelopment(controllerInput, 0, ""));

        public IActionResult Events(string controllerInput = "EventsSearch") => View(_envelopment.GetEnvelopment(controllerInput, 0, ""));

        public IActionResult News(string controllerInput = "NewsSearch") => View(_envelopment.GetEnvelopment(controllerInput, 0, ""));

        public IActionResult Artists(string controllerInput = "ArtistsSearch") => View(_envelopment.GetEnvelopment(controllerInput, 0, ""));

        public IActionResult Albums(string controllerInput = "AlbumsSearch") => View(_envelopment.GetEnvelopment(controllerInput, 0, ""));

        public IActionResult Genres(string controllerInput = "GenresSearch") => View(_envelopment.GetEnvelopment(controllerInput, 0, ""));
    }
}
