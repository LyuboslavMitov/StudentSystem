﻿using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Models
{
    //ViewModel за връзка с таблицата AspNetUsers от базата и визуализация на необходимите данни
    public class TeacherViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public string UserID { get; set; }
        [DisplayName("Име")]
        public string userName { get; set; }

        public static Expression<Func<ApplicationUser, TeacherViewModel>> FromApplicationUserModel
        {
            get
            {
                return x => new TeacherViewModel
                {   
                    UserID=x.Id,
                    userName = x.UserName,

                };
            }
        }
    }
}