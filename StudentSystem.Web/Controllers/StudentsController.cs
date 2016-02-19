//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using StudentSystem.Data;
//using StudentSystem.Web.Models;
//using StudentSystem.DatabaseModels;

//namespace StudentSystem.Web.Controllers
//{
//    public class StudentsController : BaseController
//    {
       
//        // GET: Students
//        public ActionResult Index()
//        {
//            var students = this.data.Students.All().Select(StudentViewModel.FromStudentModel).ToList();
//            return View(students);

//        }

//        // GET: Students/Details/5
//        public ActionResult Details(int? id)
//        {

//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Student foundStudentDM = this.data.Students.Find(id);
//            if (foundStudentDM == null)
//            {
//                return HttpNotFound();
//            }
//            StudentViewModel foundStudentVM = new StudentViewModel()
//            {
//                StudentID = foundStudentDM.StudentID ,
//                FirstName = foundStudentDM.FirstName,
//                SecondName = foundStudentDM.SecondName,
//                LastName = foundStudentDM.LastName,
//                Number = foundStudentDM.Number,
//                StudentClass = foundStudentDM.StudentClass.ToString()
//            };
//            return View(foundStudentVM);

   
//        }

//        // GET: Students/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // тука вече се POST-ват данните, попълнени във View-то от потребителя
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "StudentID,FirstName,SecondName,LastName,Number,Mark1,Mark2,Mark3,Mark4,Mark5,Mark6,StudentClass")] StudentViewModel studentViewModel)
//        {


//            if (!ModelState.IsValid)
//            {
//                // ако нещо не е наред, връщаме за да се попълни/коригира
//                return View(studentViewModel);
//            }
//            Student newStudent = new Student()
//            {
//                // само името - StudentClassID се създава от EntityFramework
//                // оценките и учениците се попълват от друг контролер!!!
//                FirstName = studentViewModel.FirstName,
//                SecondName = studentViewModel.SecondName,
//                LastName = studentViewModel.LastName,
//                Number = studentViewModel.Number,
//               // StudentClass=studentViewModel.StudentClass
//            };
//            this.data.Students.Add(newStudent);
//            this.data.SaveChanges();

//            // отиваме на индекса за класовете (или където искаме след успешно създаден студент)
//            return RedirectToAction("Index");
//        }
//        // GET: Students/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            StudentViewModel studentViewModel = .StudentViewModels.Find(id);
//            if (studentViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(studentViewModel);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "StudentID,FirstName,SecondName,LastName,Number,Mark1,Mark2,Mark3,Mark4,Mark5,Mark6,StudentClass")] StudentViewModel studentViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(studentViewModel).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(studentViewModel);
//        }

//        // GET: Students/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            StudentViewModel studentViewModel = db.StudentViewModels.Find(id);
//            if (studentViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(studentViewModel);
//        }

//        // POST: Students/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            StudentViewModel studentViewModel = db.StudentViewModels.Find(id);
//            db.StudentViewModels.Remove(studentViewModel);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
