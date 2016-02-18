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
        public ActionResult Index()
        {
            var studentClassList = this.data.StudentClasses.All().Select(StudentClassViewModel.FromStudentClassModel).ToList();
            SelectList selectStudentClassList = new SelectList(studentClassList, "StudentClassID", "ClassName", 0);
            var subjectList = this.data.Subjects.All().Select(SubjectViewModel.FromSubjectModel).ToList();
            SelectList selectSubjectList = new SelectList(subjectList, "SubjectID", "SubjectName",0);
            ViewData["Data1"] = selectStudentClassList;
            ViewData["Data2"] = selectSubjectList;
            return View();
        }
        public ActionResult List ()
        {
            var studentsListViewModel = this.data.Students.All().Take(10).Select(StudentViewModel.FromStudentModel).ToList();
            return View(studentsListViewModel);
        }
        public ActionResult ClassList()
        {
            var studentsClassListViewModel = this.data.StudentClasses.All().Select(StudentClassViewModel.FromStudentClassModel).ToList();
            return View(studentsClassListViewModel);
        }
    }
}