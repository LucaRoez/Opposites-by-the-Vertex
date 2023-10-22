using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Data.Repository;
using Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IViewEnvelopment _envelopment;
        private readonly IRepository _repository;

        public AdminController(ILogger<AdminController> logger, IViewEnvelopment envelopment, IRepository repository)
        {
            _logger = logger;
            _envelopment = envelopment;
            _repository = repository;
        }

        public async Task<IActionResult> Index(string message, string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, 0, message));

        public async Task<IActionResult> New(string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, 0, ""));

        public async Task<IActionResult> Modify(int id, string category, string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, id, category));

        public async Task<IActionResult> Delete(int id, string category, string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, id, category));

        public async Task<IActionResult> Create(int id, string category)
        {
            _repository.Create(await _repository.DetailOne(category, id));

            return View("Index", "It is created satisfactorily");
        }

        public async Task<IActionResult> Update(int id, string category)
        {
            _repository.Create(await _repository.DetailOne(category, id));

            return View("Index", "It is updated satisfactorily");
        }

        public async Task<IActionResult> Remove(int id, string category)
        {
            _repository.Create(await _repository.DetailOne(category, id));

            return View("Index", "It is removed satisfactorily");
        }
    }
}
