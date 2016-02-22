using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace StudentSystem.Web.Models
{
    public class TeacherAssignerViewModel : TeacherViewModel
    {
        IEnumerable<SelectListItem> StudentClasses { get; set; }
        IEnumerable<SelectListItem> Subjects { get; set; }
    }
}