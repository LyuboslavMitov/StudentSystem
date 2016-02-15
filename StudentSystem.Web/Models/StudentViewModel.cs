using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using StudentSystem.DatabaseModels;
namespace StudentSystem.Web.Models
{
    public class StudentViewModel
    {

        [Key]
        public int StudentID { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }
        public int Number { get; set; }
        public int Mark1 { get; set; }
        public int Mark2 { get; set; }
        public int Mark3 { get; set; }
        public int Mark4 { get; set; }
        public int Mark5 { get; set; }
        public int Mark6 { get; set; }
        public string StudentClass { get; set; }

        public static Expression<Func<Student, StudentViewModel>> FromStudentModel
        {
            get
            {
                return x => new StudentViewModel
                {
                    StudentID = x.StudentID,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Number = x.Number,
                    StudentClass = x.StudentClass.ClassName
                };
            }
        }

    }
}
