using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    public class AdminController : BaseController               //opitai se da scaffoldnesh
    {
        // GET: Admin
        public ActionResult StudentInput()
        {
            return View();
        }
        public ActionResult StudentClassInput()
        {
            return View();
        }
    }
}