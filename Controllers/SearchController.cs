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

        public async Task<IActionResult> Index(string adminOrder = "", string controllerInput = "IndexSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, adminOrder));

        public async Task<IActionResult> Events(string controllerInput = "EventsSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, ""));

        public async Task<IActionResult> News(string controllerInput = "NewsSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, ""));

        public async Task<IActionResult> Artists(string controllerInput = "ArtistsSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, ""));

        public async Task<IActionResult> Albums(string controllerInput = "AlbumsSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, ""));

        public async Task<IActionResult> Genres(string controllerInput = "GenresSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, ""));
    }
}
