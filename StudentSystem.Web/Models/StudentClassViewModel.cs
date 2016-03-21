using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Web.Models
{
    //ViewModel за връзка с таблицата StudentClasses от базата и визуализация на необходимите данни
    public class StudentClassViewModel
    {
        [Key]
        public int StudentClassID { get; set; }
        [DisplayName("Клас")]
        public string ClassName { get; set; }
        //Expression Funcion за по лесно превръщане от DataBase model -> ViewModel
        public static Expression<Func<StudentClass, StudentClassViewModel>> FromStudentClassModel
        {
            get
            {
                return x => new StudentClassViewModel
                {
                    StudentClassID = x.StudentClassID,
                    ClassName = x.ClassName,
                    
                };
            }
        }
    }
}