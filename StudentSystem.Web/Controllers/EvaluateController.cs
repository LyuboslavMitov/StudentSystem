using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentSystem.Web.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using StudentSystem.Data;
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
        public ActionResult List(int selectedClassId,int selectedSubjectId)
        {
            var students = this.data.Students.All()
                .Where(s => s.StudentClass.StudentClassID == selectedClassId).ToList();
            List<EvaluateStudentViewModel> result = new List<EvaluateStudentViewModel>();
            foreach (Student student in students)
            {
                EvaluateStudentViewModel studentVM = EvaluateStudentViewModel.FromStudentModelWithMarks(student, selectedSubjectId);
                studentVM.SubjectID = selectedSubjectId;
                result.Add(studentVM);
            }
            return PartialView(result);
        }
        public ActionResult Details(int selectedSubjectId, int? studentId)
        {
            if (studentId==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student foundStudent = this.data.Students.Find(studentId);
            if (foundStudent == null)
            {
                return HttpNotFound();
            }
            EvaluateStudentViewModel evaluateStudentViewModel = EvaluateStudentViewModel
                .FromStudentModelWithMarks(foundStudent, selectedSubjectId);

            return View(evaluateStudentViewModel);
        
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int studentId, int subjectId, int newMarkValue)
        {
            Student student = this.data.Students.Find(studentId);
            Subject subject = this.data.Subjects.Find(subjectId);
            ApplicationUser currentUser = CurrentUser;
            var teacher = this.data.Users.Find(currentUser.Id);
            Mark newMark = new Mark()
            {
                Subject=subject,
                SubjectID=subject.SubjectID,
                Student=student,
                StudentID=student.StudentID,
                Teacher=teacher,
                Grade=newMarkValue,
                StudentClass=student.StudentClass,
                StudentClassID=student.StudentClass.StudentClassID,
                Created=DateTime.Now,
                Term = Term.First,
                SubjectType = SubjectType.Standart,
                
            };
            this.data.Marks.Add(newMark);
            this.data.SaveChanges();


            var newMarks = this.data.Marks.All().Where(m => m.StudentID == studentId && m.SubjectID == subjectId).Select(a => a.Grade.ToString()).ToArray();


            string marks = String.Join(", ", newMarks);

            return Content(marks);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLast(int studentId, int subjectId)
        {
            Student student = this.data.Students.Find(studentId);
            Subject subject = this.data.Subjects.Find(subjectId);
            ApplicationUser currentUser = CurrentUser;
            var markToDelete = this.data.Marks.All()
                .Where(m => m.StudentID == studentId && m.SubjectID == subjectId)
                .OrderByDescending(m => m.Created).FirstOrDefault();
            if (markToDelete!=null)
            {


                if (CurrentUser.Id == markToDelete.Teacher.Id)
                {
                    this.data.Marks.Delete(markToDelete);
                    this.data.SaveChanges();
                }
            }
            
            var newMarks = this.data.Marks.All()
                .Where(m => m.StudentID == studentId && m.SubjectID == subjectId)
                .Select(a => a.Grade.ToString()).ToArray();

            string marks = String.Join(", ", newMarks);

            return Content(marks);
        }
    }
}