using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RapidD.Data;
using RapidD.BusinessLogic;

namespace RapidD.Controllers
{
    public class UserController : Controller
    {
        private UserManagement _userManagement = new UserManagement();
        // GET: User
        public ActionResult Index()
        {
            UserModel model = new UserModel();
            return View(model);
        }       

        public ActionResult Register()
        {
            return View(new UserModel() { });
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            if(ModelState.IsValid)
            {
                int userId = _userManagement.CreateUser(model);
                if (userId > 0)
                    return RedirectToAction("Index", "User");
            }
            return View("~/Views/User/Register.cshtml", model);
        }        

        public ActionResult LogOn()
        {
            UserModel model = new UserModel();            
            return View("~/Views/User/Index.cshtml", model);
        }

        public ActionResult LogOut()
        {
            UserModel model = new UserModel();
            return View("~/Views/User/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult LogOn(UserModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _userManagement.IsValidUser(model.Email, model.Password);
                if(user.UserId > 0)
                {
                    return RedirectToAction("getContacts", "contact", new { userId = user.UserId });
                }
            }
            return View("~/Views/User/Index.cshtml", model);
        }


    }
}