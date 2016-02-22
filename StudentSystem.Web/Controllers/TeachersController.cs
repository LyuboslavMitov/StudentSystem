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

namespace StudentSystem.Web.Controllers
{
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
        //public ActionResult Edit(string id)
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

        //// POST: Teachers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "UserID,userName")] TeacherAssignerViewModel teacherAssignerViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(teacherAssignerViewModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(teacherAssignerViewModel);
        //}








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
