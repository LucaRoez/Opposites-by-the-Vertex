using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Models.Services.ViewEnvelopmentSystem;
using Opuestos_por_el_Vertice.Models.ViewModels;
using System.Diagnostics;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IControllerCore _envelopment;

        public HomeController(ILogger<HomeController> logger, IControllerCore envelopment)
        {
            _logger = logger;
            _envelopment = envelopment;
        }

        public async Task<IActionResult> Index(string controllerInput = "Home") => View(await _envelopment.GetViewEnvelopment(controllerInput));

        public async Task<IActionResult> Privacy(string controllerInput = "Privacy") => View(await _envelopment.GetViewEnvelopment(controllerInput));

        public async Task<IActionResult> About(string controllerInput = "About") => View(await _envelopment.GetViewEnvelopment(controllerInput));

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}