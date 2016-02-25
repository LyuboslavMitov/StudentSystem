using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Models
{
    public class TeacherAssignerViewModel : TeacherViewModel
    {
       public IEnumerable<SelectListItem> StudentClasses { get; set; }
       public IEnumerable<SelectListItem> Subjects { get; set; }
       public bool HasStudentClasses
       {
           get
           {
               return this.StudentClasses.Any(x => x.Selected);
           }
       }
        public bool HasSubjects
       {
           get
           {
               return this.Subjects.Any(x => x.Selected);
           }
       }
    }
}