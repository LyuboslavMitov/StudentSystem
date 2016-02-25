using StudentSystem.DatabaseModels;
using StudentSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    [Authorize(Users="admin@mail.com")]
    public class AdminController : BaseController
    {

    }
}

