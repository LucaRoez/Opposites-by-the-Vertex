using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Models.Services.ViewEnvelopmentSystem;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.ViewEnvelopment;
using Opuestos_por_el_Vertice.Services.Account;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IViewEnvelopment _envelopment;
        private readonly IAccountService _account;

        public AccountController(ILogger<AccountController> logger, IViewEnvelopment envelopment, IAccountService account)
        {
            _logger = logger;
            _envelopment = envelopment;
            _account = account;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(ViewKindViewModel webInfo)
        {
            UserViewModel user = webInfo.AccountInfo.User;

            string response = await _account.RegisterUser(user);
            if (response == "true")
            {
                ViewData["Message"] = "The account was registered successfully.";
            }
            else if (response == "Passwords Unmatched")
            {
                return View(user);
            }
            else
            {
                ViewData["Message"] = response;
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            ViewData["Message"] = _account.LoginUser(email, password);
            return View();
        }
    }
}
