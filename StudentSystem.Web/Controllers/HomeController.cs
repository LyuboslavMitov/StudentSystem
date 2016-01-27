using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var name = this.data.Students.All().FirstOrDefault().FirstName;           
            return View();
        }

        public ActionResult Calendar()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Help()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Notebook()
        {
            ViewBag.Message = "Бележникът.";
            return View();
        }
        public ActionResult LoginForm()
        {
            return View();
        }
        public ActionResult RegisterForm()
        {
            return View();
        }





    }
}