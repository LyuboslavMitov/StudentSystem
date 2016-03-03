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
    /*Контролер, който позволява на админа да въвежда нови предмети*/
    public class SubjectsController : AdminController
    {

        public ActionResult Index()
        {
            var subjects = this.data.Subjects.All().Select(SubjectViewModel.FromSubjectModel).ToList();
            return View(subjects);
        }

        public ActionResult Details(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject foundSubjectDM = this.data.Subjects.Find(id);
            if (foundSubjectDM == null)
            {
                return HttpNotFound();
            }
            SubjectViewModel foundSubjectVM = new SubjectViewModel()
            {
                SubjectID = foundSubjectDM.SubjectID,
                SubjectName = foundSubjectDM.SubjectName
            };
            return View(foundSubjectVM);


        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectID,SubjectName")] SubjectViewModel subjectViewModel)
        {


            if (!ModelState.IsValid)
            {
                // ако нещо не е наред, връщаме за да се попълни/коригира
                return View(subjectViewModel);
            }
            Subject newSubject = new Subject()
            {
                SubjectName = subjectViewModel.SubjectName
            };
            if (this.data.Subjects.All().Any(s => s.SubjectName == newSubject.SubjectName))
            {
               return RedirectToAction("Index");
            }
            else
            {

                this.data.Subjects.Add(newSubject);
                this.data.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Subject subjectDM = this.data.Subjects.Find(id);
            if (subjectDM == null)
            {
                return HttpNotFound();
            }

            SubjectViewModel subjectVM = new SubjectViewModel()
            {
                SubjectID = subjectDM.SubjectID,
                SubjectName = subjectDM.SubjectName
            };

            return View(subjectVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectID,SubjectName")] SubjectViewModel subjectViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(subjectViewModel);
            }

            // намираме модела в базата за да го редактираме
            Subject subjectToUpdate = this.data.Subjects.Find(subjectViewModel.SubjectID);
            if (subjectToUpdate == null)
            {
                return HttpNotFound();
            }
            subjectToUpdate.SubjectName = subjectViewModel.SubjectName;
            if (this.data.Subjects.All().Any(s => s.SubjectName == subjectToUpdate.SubjectName))
            {
                return RedirectToAction("Index");
            }
            else
            {
                this.data.Subjects.Update(subjectToUpdate);
                this.data.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Subject subjectToDelete = this.data.Subjects.Find(id);
            if (subjectToDelete == null)
            {
                return HttpNotFound();
            }

            SubjectViewModel subjectToDeleteVM = new SubjectViewModel()
            {
                SubjectID = subjectToDelete.SubjectID,
                SubjectName = subjectToDelete.SubjectName
            };

            return View(subjectToDeleteVM);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var subjectToDelete = this.data.Subjects.Find(id);
            if (subjectToDelete == null)
            {
                return HttpNotFound();
            }

            this.data.Subjects.Delete(subjectToDelete);
            this.data.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
