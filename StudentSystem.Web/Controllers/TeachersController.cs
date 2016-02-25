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
    //[Authorize(Users="deevvil_pz@abv.bg")]
    public class TeachersController : BaseController
    {
        

        // GET: Teachers
        public ActionResult Index()
        {
            var userList = this.data.Users.All().Select(TeacherViewModel.FromApplicationUserModel).ToList();
            return View(userList);
        }


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


        // GET: Teachers/Edit/5
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

        //// POST: Teachers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int[] selectedClasses, int[] selectedSubjects, string UserID)   //Finish this shit
            {
                //ApplicationUser foundTeacher = this.data.Users.Find(UserID);
                //try
                //{
                //    List<StudentClass> classes = new List<StudentClass>();
                   

                //    foreach (var item in selectedClasses)
                //    {
                //        var foundedClass = this.data.StudentClasses.Find(item);
                //        classes.Add(foundedClass);
                //    }
                //    foundTeacher.StudentClasses.Clear();
                //    foundTeacher.StudentClasses = classes;
                //}

                //catch (NullReferenceException )
                //{
                //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                //}

                //try
                //{
                //    List<Subject> subjects = new List<Subject>();
                //    foreach (var subject in selectedSubjects)
                //    {
                //        var foundedSubject = this.data.Subjects.Find(subject);
                //        subjects.Add(foundedSubject);
                //    }
                //    foundTeacher.Subjects.Clear();
                //    foundTeacher.Subjects = subjects;
                //}

                //catch (NullReferenceException)
                //{
                //    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                //}
                //this.data.SaveChanges();
                //return RedirectToAction("Details", "Teachers", new { id = UserID });

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

                catch (NullReferenceException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
                this.data.Users.Update(foundTeacher);
                this.data.SaveChanges();
                return RedirectToAction("Details", "Teachers", new { id = UserID });
            }
            













        // GET: Teachers/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TeacherAssignerViewModel teacherAssignerViewModel = db.TeacherAssignerViewModels.Find(id);
        //    if (teacherAssignerViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(teacherAssignerViewModel);
        //}

        // POST: Teachers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    TeacherAssignerViewModel teacherAssignerViewModel = db.TeacherAssignerViewModels.Find(id);
        //    db.TeacherAssignerViewModels.Remove(teacherAssignerViewModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}
