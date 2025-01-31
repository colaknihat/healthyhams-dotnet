using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using healthyhams.Data;
using healthyhams.Data.Models;
using healthyhams.Data.Services;
using healthyhams.Web.Models;

namespace healthyhams.Web.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IUserData db;

        private readonly healthyhamsContext context;

        public SignUpController(IUserData db, healthyhamsContext context)
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
            Boolean status = context.Credentials.Any(x => x.Email == model.Email);

            if (status == true)
            {
                ViewBag.SignUpStatus = 1;
            }
            else
            {
                if (ModelState.IsValid)
                {
                    int recordsCreated = db.addCredentials(model.Email, model.Password);
                    return RedirectToAction("Index", "Survey");

                }
            }

            return View();

        }
    }
}