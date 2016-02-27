using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.Web.Models
{
    public class EvaluateStudentViewModel : StudentViewModel
    {
        List<MarkViewModel> Marks { get; set; }
        int SubjectID { get; set; }
        public static Expression<Func<Student, EvaluateStudentViewModel>> FromStudentModel
        {
            get
            {
                return x => new EvaluateStudentViewModel
                {
                    StudentID = x.StudentID,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Number = x.Number,
                    StudentClass = x.StudentClass.ClassName,
                    Marks = x.Marks.OrderBy(o => o.Created).Select(m => new MarkViewModel
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