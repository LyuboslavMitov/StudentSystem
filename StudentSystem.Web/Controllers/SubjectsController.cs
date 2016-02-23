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
    //[Authorize(Users="deevvil_pz@abv.bg")]
    public class SubjectsController : BaseController
    {
        
        // GET: Subjects
        public ActionResult Index()
        {
            var subjects = this.data.Subjects.All().Select(SubjectViewModel.FromSubjectModel).ToList();
            return View(subjects);
        }

        // GET: Subjects/Details/5
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

        // GET: Subjects/Create
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
        public ActionResult Create([Bind(Include = "SubjectID,SubjectName")] SubjectViewModel subjectViewModel)
        {


            if (!ModelState.IsValid)
            {
                // ако нещо не е наред, връщаме за да се попълни/коригира
                return View(subjectViewModel);
            }
            Subject newSubject = new Subject()
            {
                // само името - StudentClassID се създава от EntityFramework
                // оценките и учениците се попълват от друг контролер!!!
                SubjectName = subjectViewModel.SubjectName
            };
            this.data.Subjects.Add(newSubject);
            this.data.SaveChanges();

            // отиваме на индекса за класовете (или където искаме след успешно създаден клас)
            return RedirectToAction("Index");
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int? id)
        {

            // практически кода се дублира с този от Details(id)
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

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectID,SubjectName")] SubjectViewModel subjectViewModel)
        {
            if (!ModelState.IsValid) // по-четимо е като излезем веднага при проблем
            {
                // не е наред, връщаме за да се попълни/коригира
                return View(subjectViewModel);
            }

            // намираме модела в базата за да го редактираме
            Subject subjectToUpdate = this.data.Subjects.Find(subjectViewModel.SubjectID);
            if (subjectToUpdate == null)
            {
                return HttpNotFound();
            }

            // всичко е ок дотук

            subjectToUpdate.SubjectName = subjectViewModel.SubjectName;
            // другите неща - на други места, тук само името

            this.data.Subjects.Update(subjectToUpdate);
            this.data.SaveChanges();

            return RedirectToAction("Index");
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



        // POST: StudentClasses/Delete/5
        // Потребителя е потвърдил че ще трие
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var subjectToDelete = this.data.Subjects.Find(id);
            if (subjectToDelete == null)
            {
                return HttpNotFound();
            }

            // по принцип данни не се трият а се крият
            // може да се наложи обхождане на пропъртитата - оценки и ученици 
            // и да се трият ако е нужно и след това самия клас!

            this.data.Subjects.Delete(subjectToDelete);
            this.data.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
