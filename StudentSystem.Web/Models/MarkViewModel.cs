using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem.Web.Models
{
    //ViewModel за връзка с таблицата Marks от базата и визуализация на необходимите данни
    public class MarkViewModel
    {
        [Key]
        public int MarkID { get; set; }
        public DateTime Created { get; set; }
        public int Grade { get; set; }
    }
}