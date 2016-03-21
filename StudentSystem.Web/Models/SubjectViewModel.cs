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
    //ViewModel за връзка с таблицата Subhects от базата и визуализация на необходимите данни
    public class SubjectViewModel
    {
        [Key]
        public int SubjectID { get; set; }
        [DisplayName("Предмет")]
        public string SubjectName { get; set; }
        //Expression Funcion за по лесно превръщане от DataBase model -> ViewModel
        public static Expression<Func<Subject, SubjectViewModel>> FromSubjectModel            
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