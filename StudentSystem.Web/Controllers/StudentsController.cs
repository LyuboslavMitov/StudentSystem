using StudentSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    public class StudentsController : BaseController
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List ()
        {
            var studentsListViewModel = this.data.Students.All().Take(10).Select(StudentViewModel.FromStudentModel).ToList();

            return View(studentsListViewModel);
        }
    }
}