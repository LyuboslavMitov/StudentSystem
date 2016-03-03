using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Web.Models
{
    //ViewModel за връзка с таблицата Students от базата и визуализация на необходимите данни
    public class StudentViewModel
    {
    
        [Key]
        public int StudentID { get; set; }
        
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }
        public int Number { get; set; }
        public string StudentClass { get; set; }
        public int StudentClassID { get; set; }

        //Expression Funcion за по лесно превръщане от DataBase model -> ViewModel
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
