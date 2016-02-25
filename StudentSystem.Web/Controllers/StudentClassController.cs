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

    public class StudentClassController : AdminController 
    {

        
        // GET: StudentClass

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

        // POST: StudentClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                // само името - StudentClassID се създава от EntityFramework
                // оценките и учениците се попълват от друг контролер!!!
                ClassName = studentClassViewModel.ClassName
            };
            this.data.StudentClasses.Add(newClass);
            this.data.SaveChanges();

            // отиваме на индекса за класовете (или където искаме след успешно създаден клас)
            return RedirectToAction("Index");
        }

        // GET: StudentClass/Edit/5
        // както на детайлите - зареждаме модела и го подаваме с View за редакция!
        public ActionResult Edit(int? id)
        {
           
            // практически кода се дублира с този от Details(id)
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
            
            if (!ModelState.IsValid) // по-четимо е като излезем веднага при проблем
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

            // всичко е ок дотук

            studentClassToUpdate.ClassName = studentClassViewModel.ClassName;
            // другите неща - на други места, тук само името

            this.data.StudentClasses.Update(studentClassToUpdate);
            this.data.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: StudentClass/Delete/5

        // GET: StudentClasses/Delete/5
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



        // POST: StudentClasses/Delete/5
        // Потребителя е потвърдил че ще трие
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var classToDelete = this.data.StudentClasses.Find(id);
            if (classToDelete == null)
            {
                return HttpNotFound();
            }

            // по принцип данни не се трият а се крият
            // може да се наложи обхождане на пропъртитата - оценки и ученици 
            // и да се трият ако е нужно и след това самия клас!

            this.data.StudentClasses.Delete(classToDelete);
            this.data.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}

