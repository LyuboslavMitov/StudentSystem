using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem.Web.Models
{
    public class StudentClassViewModel
    {
        [Key]
        public int StudentClassID { get; set; }
        public string ClassName { get; set; }
    }
}