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

        public async Task<IActionResult> Index(string adminOrder = "", int page = 1, string controllerInput = "IndexSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, page, adminOrder));

        public async Task<IActionResult> Events(int page = 1, string controllerInput = "EventsSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, page, ""));

        public async Task<IActionResult> News(int page = 1, string controllerInput = "NewsSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, page, ""));

        public async Task<IActionResult> Artists(int page = 1, string controllerInput = "ArtistsSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, page, ""));

        public async Task<IActionResult> Albums(int page = 1, string controllerInput = "AlbumsSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, page, ""));

        public async Task<IActionResult> Genres(int page = 1, string controllerInput = "GenresSearch") => View(await _envelopment.GetEnvelopment(controllerInput, 0, page, ""));
    }
}
