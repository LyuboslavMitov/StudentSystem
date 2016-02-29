using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Web.Models
{
    //View model за генерирането на таблицата с оценките
    public class TableViewModel
    {
        List<EvaluateStudentViewModel> Students { get; set; }
        public int SubjectID{get;set;}
        int StudentClassID{get;set;}
    }
}