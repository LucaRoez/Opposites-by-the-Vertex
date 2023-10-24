using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Models.Services.View_Envelopment_System;
using Opuestos_por_el_Vertice.Models.Services.ViewModels;
using Opuestos_por_el_Vertice.Models.ViewModels;
using Opuestos_por_el_Vertice.Services.AdminManager;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IViewEnvelopment _envelopment;
        private readonly IAdminManager _admin;

        public AdminController(ILogger<AdminController> logger, IViewEnvelopment envelopment, IAdminManager admin)
        {
            _logger = logger;
            _envelopment = envelopment;
            _admin = admin;
        }

        public async Task<IActionResult> Index(string message = "", string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, 0, message));

        public async Task<IActionResult> New(string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, 0, ""));

        public async Task<IActionResult> Modify(int id, string category, string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, id, category));

        public async Task<IActionResult> Delete(int id, string category, string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, id, category));

        [HttpPost]
        public async Task<IActionResult> Create(ViewKindViewModel post)
        {
            post.ObjectClass.CurrentPost.PublicationDate = DateTime.Now;
            await _admin.CreateNewPost(post.ObjectClass.CurrentPost);
            TempData["AdminMessage"] = "It is created satisfactorily";

            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string category)
        {
            await _admin.UpdatePost(id, category);

            return View("Index", "It is updated satisfactorily");
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id, string category)
        {
            await _admin.RemovePost(id, category);

            return View("Index", "It is removed satisfactorily");
        }
    }
}
