using Microsoft.AspNetCore.Mvc;
using Opuestos_por_el_Vertice.Data.Entities;
using Opuestos_por_el_Vertice.Models.Services.ViewEnvelopmentSystem;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.Account;
using Opuestos_por_el_Vertice.Models.Services.ViewModels.ViewEnvelopment;
using Opuestos_por_el_Vertice.Services.Account;
using Opuestos_por_el_Vertice.Services.EmailSender;

namespace Opuestos_por_el_Vertice.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IViewEnvelopment _envelopment;
        private readonly IAccountService _account;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountController(
            ILogger<AccountController> logger, IViewEnvelopment envelopment,
            IAccountService account, IWebHostEnvironment webHostEnvironment
            )
        {
            _logger = logger;
            _envelopment = envelopment;
            _account = account;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Register() => View(await _envelopment.GetViewEnvelopment("Account"));

        [HttpPost]
        public async Task<IActionResult> Register(ViewKindViewModel webInfo)
        {
            ModelState.Remove("User.FirstName"); ModelState.Remove("User.LastName");
            ModelState.Remove("User.Phone"); ModelState.Remove("User.Token");
            ModelState.Remove("ObjectsClass.SelectedPost.Image"); ModelState.Remove("ObjectsClass.SelectedPost.Author");
            ModelState.Remove("ObjectsClass.SelectedPost.Title"); ModelState.Remove("ObjectsClass.SelectedPost.SubTitle");
            if (ModelState.IsValid)
            {
                UserViewModel? user = webInfo.User;

                string response = await _account.RegisterUser(user);
                ViewData["Message"] = response;
                if (response == "true")
                {
                    try
                    {
                        UserViewModel? User = await _account.GetUser(user.Email);
                        SendEmail(user, User);
                        ViewData["Message"] = @"The account was registered successfully. And an email was sent to your email inbox" +
                            "to confirm that you actually are youself";
                    }
                    catch (Exception ex)
                    {
                        ViewData["Message"] = ex.Message;
                    }
                }
                else if (response == "Passwords Unmatched")
                {
                    ModelState.AddModelError("", "Passwords do not match");
                    return View(webInfo);
                }

                return RedirectToAction("Index", "Home", await _envelopment.GetViewEnvelopment("Home"));
            }
            return View(await _envelopment.GetViewEnvelopment("Account"));
        }

        public async Task<IActionResult> Login() => View(await _envelopment.GetViewEnvelopment("Account"));

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            string loginMessage = await _account.LoginUser(email, password);
            ViewData["Message"] = loginMessage;
            if (loginMessage == "User logged successfully")
            {
                return RedirectToAction("Index", "Home", await _envelopment.GetViewEnvelopment("Account"));
            }
            return View("Login", await _envelopment.GetViewEnvelopment("Account"));
        }

        //public IAccountResult Reconfirm()
        //{

        //}

        public async Task<IActionResult> Confirm(string token)
        {
            if (await _account.ConfirmUser(token))
            {
                ViewData["Message"] = "Your email was confirmed succesfully, welcome to our page!";
            }
            else
            {
                ViewData["Message"] = "There's no email registered in our data base";
            }
            return View(_envelopment.GetViewEnvelopment("Account"));
        }

        public async Task<IActionResult> Restore(string token, string password)
        {
            string response = await _account.ReestablishUser(token, password);
            ViewData["Message"] = response;
            return View(_envelopment.GetViewEnvelopment("Account"));
        }

        private void SendEmail(UserViewModel user, UserViewModel User)   // user = entity posted - User = entity from repository
        {
            string path = Path.Combine(_webHostEnvironment.ContentRootPath,
                "Models/Services/EmailSender/HtmlTemplates/ConfirmationEmail.html");
            string content = System.IO.File.ReadAllText(path);
            string url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/account/confirm?token={User.Token}";
            string htmlBody;
            if (user.FirstName != null)
            {
                htmlBody = string.Format(content, User.FirstName, url);
            }
            else
            {
                if (user.FirstName != "") { htmlBody = string.Format(content, User.FirstName, url); }
                else { htmlBody = string.Format(content, User.UserName, url); }                
            }

            EmailSender.Send(User.Email, htmlBody);
        }
    }
}
