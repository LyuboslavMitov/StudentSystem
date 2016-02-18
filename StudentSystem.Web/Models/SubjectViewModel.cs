using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System;
namespace StudentSystem.Web.Models
{
    public class SubjectViewModel
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public static Expression<Func<Subject, SubjectViewModel>> FromSubjectModel            //Subject View Model
        {
            get
            {
                return x => new SubjectViewModel
                {
                    SubjectID = x.SubjectID,
                    SubjectName = x.SubjectName,
                };
            }
        }
    }
}