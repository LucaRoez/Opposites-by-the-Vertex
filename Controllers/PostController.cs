using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Models.Services.ViewEnvelopmentSystem;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IControllerCore _envelopment;

        public PostController(ILogger<PostController> logger, IControllerCore envelopment)
        {
            _logger = logger;
            _envelopment = envelopment;
        }

        public async Task<IActionResult> Post(int id, string postCategory, string controllerInput = "Post") => View(await _envelopment.GetViewEnvelopment(controllerInput, id, postCategory));
    }
}
