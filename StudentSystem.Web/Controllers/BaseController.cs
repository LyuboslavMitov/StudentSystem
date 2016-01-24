using StudentSystem.Data.UnitOfWork;
using System.Web;
using System.Web.Mvc;

namespace StudentSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IStudentSystemData data;
        public BaseController ()
	{
        this.data = new StudentSystemData();
	}

    }
}