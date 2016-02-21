using StudentSystem.Data.UnitOfWork;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
namespace StudentSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IStudentSystemData data;
        public BaseController ()
	{
        this.data = new StudentSystemData();
	}
        protected List<SelectListItem> StudentClassesSelectList()
        {
            var studentClassesList = this.data.StudentClasses.All().Select(x => new SelectListItem
            {
                Text = x.ClassName,
                Value = x.StudentClassID.ToString()
            }).ToList();
            return studentClassesList;
        }
    }
}