using Inveon.Core.Common;
using Inveon.Entities.Concrete.Dto;
using Inveon.Services.Abstract;
using Inveon.WebUI.Models.Account;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace Inveon.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService  _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new LoginDto();
            Mapper.PropertyMap(model, dto);
            var result = _accountService.Login(dto);

            if (result)
            {
                var sd = new List<string>()
                {
                    "Admin",
                    "Normal"
                };
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToAction("Index", "Management");
            }

            ModelState.AddModelError("", "Invalid Username or Password");
            return View();
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = new RegisterDto();
            Mapper.PropertyMap(model, dto);

            var result = _accountService.Register(dto);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(model.Username, false);
                return RedirectToAction("Index", "Management");
            }

            ModelState.AddModelError("", "Invalid Username or Password");
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}