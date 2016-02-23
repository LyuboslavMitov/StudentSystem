using StudentSystem.DatabaseModels;
using StudentSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace StudentSystem.Web.Controllers
{
    [RequireHttps]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //var name = this.data.Students.All().FirstOrDefault().FirstName;           
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
        public ActionResult Notebook(string id)
        {
            id = User.Identity.GetUserId();
            //ApplicationUser foundTeacher = this.data.Users.Find(id);
            if (id== null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> teacherClasses = this.TeacherClassesList(id);
            List<SelectListItem> teacherSubjects = this.TeacherSubjectsList(id);
            ViewBag.Message = "Бележникът.";
            var enumerableTeacherClasses = teacherClasses as IEnumerable<SelectListItem>;
            ViewData["EnumerableTeacherClasses"] = enumerableTeacherClasses;
            ViewData["TeacherSubjects"] = teacherSubjects;
            return View();
        }
        public ActionResult Insert()
        {
            return View();

        }
        public ActionResult loginform()
        {
            var studentClassList = this.data.StudentClasses.All().Select(StudentClassViewModel.FromStudentClassModel).ToList();
            SelectList selectStudentClassList = new SelectList(studentClassList, "StudentClassID", "ClassName", 0);
            var subjectList = this.data.Subjects.All().Select(SubjectViewModel.FromSubjectModel).ToList();
            SelectList selectSubjectList = new SelectList(subjectList, "SubjectID", "SubjectName", 0);
            ViewData["Data1"] = selectStudentClassList;
            ViewData["Data2"] = selectSubjectList;
            return View();
        }
    }
}