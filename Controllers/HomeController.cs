using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System;
using Opuestos_por_el_Vertice.Models.ViewModels;
using System.Diagnostics;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IViewEnvelopment _envelopment;

        public HomeController(ILogger<HomeController> logger, IViewEnvelopment envelopment)
        {
            _logger = logger;
            _envelopment = envelopment;
        }

        public IActionResult Index(string controllerInput = "Home") => View(_envelopment.GetEnvelopment(controllerInput, 0, ""));

        public IActionResult Privacy(string controllerInput = "Privacy") => View(_envelopment.GetEnvelopment(controllerInput, 0, ""));

        public IActionResult About(string controllerInput = "About") => View(_envelopment.GetEnvelopment(controllerInput, 0, ""));

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}