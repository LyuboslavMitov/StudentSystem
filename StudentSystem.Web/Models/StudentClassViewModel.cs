using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Web.Models
{
    public class StudentClassViewModel
    {
        [Key]
        public int StudentClassID { get; set; }
        public string ClassName { get; set; }

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