using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using healthyhams.Data.Services;
using healthyhams.Data;
using healthyhams.Web.Models;


namespace healthyhams.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserData db;

        private readonly healthyhamsContext context;

        public LoginController(IUserData db, healthyhamsContext context)
        {
            this.db = db;
            this.context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SignUpViewModel model)
        {
            var status = context.Credentials.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                int userId = context.Credentials.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault().CredentialsId;
                string email = context.Credentials.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault().Email;
                string password = context.Credentials.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault().Password;

                Session["userId"] = userId;
                Session["userEmail"] = email;
                Session["userPassword"] = password;

                return RedirectToAction("User", "Home", new { id = userId });
            }

            return View();
        }
    }
}