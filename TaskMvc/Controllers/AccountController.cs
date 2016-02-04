using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic;
using Web.Models;

namespace TaskMvc.Controllers
{
    public class AccountController : Controller
    {
        private DataManager dataManager;

        public AccountController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (dataManager.MembershipProvider.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Не вдала спроба входу на сайт");
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            //Провіряємо чи користуач ввів все вірно
            if (ModelState.IsValid)
            {
                MembershipCreateStatus status = dataManager.MembershipProvider.CreateUser(model.UserName, model.Password,
                                                                                          model.Email, model.FirstName,
                                                                                          model.LastName, model.MiddleName);
                if (status == MembershipCreateStatus.Success)
                    return View("Success");
                ModelState.AddModelError("", GetMembershipCreateStatusResultText(status));
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        //Створюємо текс помилки для MembershiopCreateStatus

        public string GetMembershipCreateStatusResultText(MembershipCreateStatus status)
        {
            if (status == MembershipCreateStatus.DuplicateEmail)
                return "Користувач з таки email вже існує";
            if (status == MembershipCreateStatus.DuplicateUserName)
                return "Користувач з таким іменем вже існує";
            return "Невідома помилка";

        }
    }
}
