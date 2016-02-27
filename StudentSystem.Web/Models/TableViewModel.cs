using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentSystem.Web.Models
{
    public class TableViewModel
    {
        List<EvaluateStudentViewModel> Students { get; set; }
        public int SubjectID{get;set;}
        int StudentClassID{get;set;}
    }
}