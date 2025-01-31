using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using healthyhams.Data;
using healthyhams.Data.Models;
using healthyhams.Data.Services;

namespace healthyhams.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IUserData db;

        private readonly healthyhamsContext context;

        public SurveyController(IUserData db, healthyhamsContext context)
        {
            this.db = db;
            this.context = context;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Survey";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserInformation model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = db.addUserInformation(model.Username, model.Birthday, model.Gender, model.Height, model.Weight, model.WeightGoal, model.ActivityLevel);
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}