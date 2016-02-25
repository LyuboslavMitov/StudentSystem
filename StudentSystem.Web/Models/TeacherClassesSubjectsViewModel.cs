using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace StudentSystem.Web.Models
{
    public class TeacherClassesSubjectsViewModel
    {
        public List<SelectListItem> Subjects;
        public List<SelectListItem> Classes;
        public int SubjectId { get; set; }
        public int ClassId { get;set; }
    }
}