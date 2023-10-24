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

        public async Task<IActionResult> Index(string message = "", int page = 0, string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, 0, page, message));

        public async Task<IActionResult> New(int page = 0, string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, 0, page, ""));

        public async Task<IActionResult> Modify(int id, string category, int page = 0, string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, id, page, category));

        public async Task<IActionResult> Delete(int id, string category, int page = 0, string controllerInput = "Admin") => View(await _envelopment.GetEnvelopment(controllerInput, id, page, category));

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
            TempData["AdminMessage"] = "It is updated satisfactorily";

            return View("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id, string category)
        {
            await _admin.RemovePost(id, category);
            TempData["AdminMessage"] = "It is removed satisfactorily";

            return View("Index");
        }
    }
}
