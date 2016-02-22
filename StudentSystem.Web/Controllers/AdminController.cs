using StudentSystem.DatabaseModels;
using StudentSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    public class AdminController : BaseController
    {

        public ActionResult Index()
        {
            //AdminStudentViewModel adminStudentViewModel = new AdminStudentViewModel();
            // PODAVANE NA DANNI ZA DROPDOWNLISTOVE - Purva Versiq
            /*Getting data from database*/
            List<StudentClass> studentclasslist = (from data in this.data.StudentClasses.All() select data).ToList();
            StudentClass studentclass = new StudentClass();
            studentclass.ClassName = "Select";
            studentclass.StudentClassID = 0;
            studentclasslist.Insert(0, studentclass);
            SelectList objmodeldata = new SelectList(studentclasslist, "StudentClassID", "ClassName", 0);
            /*Assign value to model*/
            AdminStudentViewModel studentclassmodel = new AdminStudentViewModel();
            studentclassmodel.StudentClassesList = objmodeldata;
            return View(studentclassmodel);

            // PODAVANE NA DANNI ZA DROPDOWNLISTOVE - VTORA VERSIQ
            //var studentClassList = this.data.StudentClasses.All().Select(StudentClassViewModel.FromStudentClassModel).ToList();
            //SelectList selectStudentClassList = new SelectList(studentClassList, "StudentClassID", "ClassName", 0);
            //var subjectList = this.data.Subjects.All().Select(SubjectViewModel.FromSubjectModel).ToList();
            //SelectList selectSubjectList = new SelectList(subjectList, "SubjectID", "SubjectName", 0);
            //ViewData["Data1"] = selectStudentClassList;
            //ViewData["Data2"] = selectSubjectList;
            
        }

    }
}

