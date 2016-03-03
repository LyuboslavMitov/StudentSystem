using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Web.Models
{
    //ViewModel за оценяването на ученици
    public class EvaluateStudentViewModel : StudentViewModel
    {
        public List<MarkViewModel> Marks { get; set; }
        public int SubjectID { get; set; }
        [Range(2, 6, ErrorMessage = "Между 2 - 6.")]
        public int NewMark { get; set; }       
        public static Func<Student, int, EvaluateStudentViewModel> FromStudentModelWithMarks
        {
            get
            {
                return (x, i) => new EvaluateStudentViewModel
                {
                    StudentID = x.StudentID,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Number = x.Number,
                    StudentClass = x.StudentClass.ClassName,
                    StudentClassID = x.StudentClass.StudentClassID,
                    Marks = x.Marks.Where(m => m.SubjectID == i).OrderBy(o => o.Created).Select(m => new MarkViewModel
                    {
                        MarkID = m.MarkID,
                        Created = m.Created,
                        Grade = m.Grade
                    }).ToList()
                };
            }
        }
    }
}
