using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic;
using Domain.Entities;
using TaskMvc.Models;

namespace TaskMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private DataManager dataManager;
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }
    
        public ActionResult Index()
        {
            List<UserModel> model = new List<UserModel>();
            foreach (User user in dataManager.Users.GetUsers())
            {
                model.Add(new UserModel{User = user});
            }

            User autorizeUser = dataManager.Users.GetUserById((int)Membership.GetUser().ProviderUserKey);

            ViewData["FirstName"] = autorizeUser.FirstName;
            ViewData["LastName"] = autorizeUser.LastName;

            if (Request.IsAjaxRequest())
                return PartialView("_UsersData");

            

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new User{CreatedDate = DateTime.Now});
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
           
            if (ModelState.IsValid)
            {
               dataManager.Users.CreateUser(user.UserName, user.Password, user.Email,user.FirstName,user.LastName,user.MiddleName);
                return RedirectToAction("Index","Home");
            }
            return View(user);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = dataManager.Users.GetUserById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(
            [Bind(Include = "Id, UserName, Password, Email,CreatedDate, FirstName, LastName, MiddleName")] User user)
        {
            if (ModelState.IsValid)
            {
                dataManager.Users.SaveUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            User user = dataManager.Users.GetUserById(id);
            dataManager.Users.DeleteUser(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
