using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentSystem.Data;
using StudentSystem.Web.Models;
using StudentSystem.DatabaseModels;
using System.Data.Entity.Infrastructure;

namespace StudentSystem.Web.Controllers
{
    /* Контролер който позволява на админа да зададе кой учител на кои класове преподава
     * и кой учител по кои предмети преподава чрез checkboxList-ове*/
    public class TeachersController : AdminController
    {
        //Връща списък с всички регистрирани потребители
        public ActionResult Index()
        {
            var userList = this.data.Users.All().Select(TeacherViewModel.FromApplicationUserModel).ToList();
            return View(userList);
        }

        /*Страница, която показва избраният учител на кои класове преподава
          и по кои предмети преподава*/
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser foundTeacher = this.data.Users.Find(id);
            if (foundTeacher == null)
            {
                return HttpNotFound();
            }
            TeacherAssignerViewModel foundTeacherVM = new TeacherAssignerViewModel()
            {
                UserID = foundTeacher.Id,
                userName = foundTeacher.UserName,
                StudentClasses = this.TeacherClassesList(id),
                Subjects = this.TeacherSubjectsList(id)
            };
            return View(foundTeacherVM);
        }
       
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser foundTeacher = this.data.Users.Find(id);
            if (foundTeacher == null)
            {
                return HttpNotFound();
            }
            TeacherAssignerViewModel foundTeacherVM = new TeacherAssignerViewModel()
            {
                UserID = foundTeacher.Id,
                userName = foundTeacher.UserName,
                StudentClasses = this.TeacherClassesList(id),
                Subjects = this.TeacherSubjectsList(id)
            };
            return View(foundTeacherVM);
        }

        /* От тук се връща View, което позволява задаване и редакция на предметите и класовете
        по които преподава учителят който сте избрали от Index страницата*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int[] selectedClasses, int[] selectedSubjects, string UserID) 
            {
                ApplicationUser foundTeacher = this.data.Users.Find(UserID);
                foundTeacher.StudentClasses.Clear();
                foundTeacher.Subjects.Clear();
                try
                {
                    List<StudentClass> classes = new List<StudentClass>();

                    if (selectedClasses != null)
                    {
                        foreach (var item in selectedClasses)
                        {
                            var foundedClass = this.data.StudentClasses.Find(item);
                            classes.Add(foundedClass);
                        }
                        foundTeacher.StudentClasses = classes;
                    }
                }
                //Не позволява да остави, някой учител без класове на които да преподава
                catch (NullReferenceException )
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }

                try
                {
                    if (selectedSubjects != null)
                    {
                        List<Subject> subjects = new List<Subject>();
                        foreach (var subject in selectedSubjects)
                        {
                            var foundedSubject = this.data.Subjects.Find(subject);
                            subjects.Add(foundedSubject);
                        }
                        
                        foundTeacher.Subjects = subjects;
                    }
                }
                //Не позволява да остави, някой учител без предмети по които да преподава
                catch (NullReferenceException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                this.data.Users.Update(foundTeacher);
                this.data.SaveChanges();
                return RedirectToAction("Details", "Teachers", new { id = UserID });
            }
    }
}
