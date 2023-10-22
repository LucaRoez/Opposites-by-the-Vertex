using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IViewEnvelopment _envelopment;

        public PostController(ILogger<PostController> logger, IViewEnvelopment envelopment)
        {
            _logger = logger;
            _envelopment = envelopment;
        }

        public async Task<IActionResult> Post(int id, string postCategory, string controllerInput = "Post") => View(await _envelopment.GetEnvelopment(controllerInput, id, postCategory));
    }
}
