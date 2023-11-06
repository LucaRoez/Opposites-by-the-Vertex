using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Models.Services.ViewEnvelopmentSystem;
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

        public async Task<IActionResult> Index(string message = "", string controllerInput = "Admin") => View(await _envelopment.GetModelEnvelopment(controllerInput, 0, message));

        public async Task<IActionResult> New(string controllerInput = "Admin") => View(await _envelopment.GetModelEnvelopment(controllerInput, 0, ""));

        public async Task<IActionResult> Modify(int id, string category, string controllerInput = "Admin") => View(await _envelopment.GetModelEnvelopment(controllerInput, id, category));

        public async Task<IActionResult> Delete(int id, string category, string controllerInput = "Admin") => View(await _envelopment.GetModelEnvelopment(controllerInput, id, category));

        [HttpPost]
        public async Task<IActionResult> DeleteAll(string identifier, int id = 0, string controllerInput = "Admin") => View(await _envelopment.GetModelEnvelopment(controllerInput, id, identifier));

        [HttpPost]
        public async Task<IActionResult> Create(ViewKindViewModel webInfo)
        {
            ModelState.Remove("ObjectClass.CurrentPost.Body");
            if (ModelState.IsValid)
            {
                var post = webInfo.ObjectClass.CurrentPost;
                post.CategoryId = webInfo.AdminInfo.CategoryId;
                post.PublicationDate = DateTime.Now;

                await _admin.CreateNewPost(post);
                TempData["AdminMessage"] = "It is created satisfactorily.";

                return RedirectToAction("Index");
            }
            return View("New", await _envelopment.GetModelEnvelopment("Admin", 0, ""));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ViewKindViewModel webInfo)
        {
            ModelState.Remove("ObjectClass.CurrentPost.Body");
            if (ModelState.IsValid)
            {
                var post = webInfo.ObjectClass.CurrentPost;
                int categoryId = webInfo.AdminInfo.CategoryId;
                if (categoryId != 0) { post.CategoryId = categoryId; }
                else { categoryId = post.CategoryId; }

                await _admin.UpdatePost(post.Id, post, post.Category);
                TempData["AdminMessage"] = "It is updated satisfactorily.";

                return RedirectToAction("Index");
            }
            return View("Modify", await _envelopment.GetModelEnvelopment("Admin", 0, ""));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id, string category)
        {
            if (!string.IsNullOrEmpty(category) || !string.IsNullOrEmpty(id.ToString()))
            {
                await _admin.RemovePost(id, category);
                TempData["AdminMessage"] = "It is removed satisfactorily.";

                return RedirectToAction("Index");
            }
            TempData["AdminMessage"] = "There was an error while model data collection attempt.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAll(string identifier)
        {
            if (!string.IsNullOrEmpty(identifier))
            {
                await _admin.RemoveAll(identifier);
                TempData["AdminMessage"] = "All publications were removed satisfactorily.";

                return RedirectToAction("Index");
            }
            TempData["AdminMessage"] = "There was an error while model data collection attempt.";
            return RedirectToAction("Index");
        }
    }
}
