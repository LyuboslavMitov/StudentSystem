using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    public class EvaluateController : BaseController
    {
        
        public ActionResult Index()
        {
            ApplicationUser currentUser = CurrentUser;
            string id = currentUser.Id;
            List<SelectListItem> currentTeacherClasses = this.TeacherClassesList(id).Where(x => x.Selected).ToList();
            List<SelectListItem> currentTeacherSubjects = this.TeacherSubjectsList(id).Where(x => x.Selected).ToList();
            ViewBag.CurrentTeacherClasses = currentTeacherClasses;
            ViewBag.CurrentTeacherSubjects = currentTeacherSubjects;
            return View();
        }
    }
}