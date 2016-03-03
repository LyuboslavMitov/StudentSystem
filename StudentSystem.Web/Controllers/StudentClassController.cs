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
    //Контролер, който позволява на админа да въвежда нови класове
    public class StudentClassController : AdminController
    {
        public ActionResult Index()
        {
            var classes = this.data.StudentClasses.All().Select(StudentClassViewModel.FromStudentClassModel).ToList();
            return View(classes);
        }

        public ActionResult Details(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentClass foundClassDM = this.data.StudentClasses.Find(id);
            if (foundClassDM == null)
            {
                return HttpNotFound();
            }
            StudentClassViewModel foundClassVM = new StudentClassViewModel()
            {
                StudentClassID = foundClassDM.StudentClassID,
                ClassName = foundClassDM.ClassName
            };
            return View(foundClassVM);

        }


        // тука създава чисто View за създаване на клас и го връща за въвеждане
        public ActionResult Create()
        {
            return View();
        }
        // тука вече се POST-ват данните, попълнени във View-то от потребителя
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentClassID,ClassName")] StudentClassViewModel studentClassViewModel)
        {


            if (!ModelState.IsValid)
            {
                // ако нещо не е наред, връщаме за да се попълни/коригира
                return View(studentClassViewModel);
            }
            StudentClass newClass = new StudentClass()
            {

                ClassName = studentClassViewModel.ClassName
            };
            ViewBag.Message = "";
            if (this.data.StudentClasses.All().Any(c => c.ClassName == newClass.ClassName))
            {
                ViewBag.Message = "Класът, който се опитахте да въведете вече съществува!";
                return RedirectToAction("Index");
            }
            else
            {
                this.data.StudentClasses.Add(newClass);
                this.data.SaveChanges();
                ViewBag.Message = "Класът е създаден успешно!";
                return RedirectToAction("Index");
            }
        }

        // както на детайлите - зареждаме модела и го подаваме с View за редакция!
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudentClass foundClassDM = this.data.StudentClasses.Find(id);
            if (foundClassDM == null)
            {
                return HttpNotFound();
            }

            StudentClassViewModel foundClassVM = new StudentClassViewModel()
            {
                StudentClassID = foundClassDM.StudentClassID,
                ClassName = foundClassDM.ClassName
            };

            return View(foundClassVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentClassID,ClassName")] StudentClassViewModel studentClassViewModel)
        {

            if (!ModelState.IsValid)
            {
                // не е наред, връщаме за да се попълни/коригира
                return View(studentClassViewModel);
            }

            // намираме модела в базата за да го редактираме
            StudentClass studentClassToUpdate = this.data.StudentClasses.Find(studentClassViewModel.StudentClassID);
            if (studentClassToUpdate == null)
            {
                return HttpNotFound();
            }
            //сменя името
            studentClassToUpdate.ClassName = studentClassViewModel.ClassName;
            if (this.data.StudentClasses.All().Any(c => c.ClassName == studentClassToUpdate.ClassName))
            {
                return RedirectToAction("Index");
            }
            else
            {

                this.data.StudentClasses.Update(studentClassToUpdate);
                this.data.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // взима ViewModel на класа за триене и го връща на юзъра за потвърждение
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StudentClass classToDelete = this.data.StudentClasses.Find(id);
            if (classToDelete == null)
            {
                return HttpNotFound();
            }

            StudentClassViewModel classToDeleteVM = new StudentClassViewModel()
            {
                StudentClassID = classToDelete.StudentClassID,
                ClassName = classToDelete.ClassName
            };

            return View(classToDeleteVM);

        }

        // Админът е потвърдил че ще трие
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var classToDelete = this.data.StudentClasses.Find(id);
            if (classToDelete == null)
            {
                return HttpNotFound();
            }

            this.data.StudentClasses.Delete(classToDelete);
            this.data.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

