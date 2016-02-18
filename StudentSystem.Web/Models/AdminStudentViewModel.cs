using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Models
{
    public class AdminStudentViewModel
    {
        [Key]
        public int StudentID { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }
        public int Number { get; set; }
        public SelectList StudentClassesList { get; set; }          // FOR DROPDOWN LIST in the Admin Panel
      //  public int StudentClassID { get; set; }
        public static Expression<Func<Student, AdminStudentViewModel>> FromStudentModel
        {
            get
            {
                return x => new AdminStudentViewModel
                {
                    StudentID = x.StudentID,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Number = x.Number,
                   // StudentClass = x.StudentClass.ClassName
                };
            }
        }
    }
}