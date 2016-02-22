using StudentSystem.Data.UnitOfWork;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using StudentSystem.DatabaseModels;
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
        protected List<SelectListItem> TeacherClassesList(string id)
    {
        var teacherClassesList = this.data.StudentClasses.All().Where(c => c.Teachers.Any(t => t.Id == id)).Select(x => new SelectListItem
            {
                Text = x.ClassName,
                Value = x.StudentClassID.ToString()
            }).ToList();
        return teacherClassesList;
    }
        protected List<SelectListItem> TeacherSubjectsList(string id)
        {
            var teacherSubjectsList = this.data.Subjects.All().Where(c => c.Teachers.Any(t => t.Id == id)).Select(x => new SelectListItem
            {
                Text = x.SubjectName,
                Value = x.SubjectID.ToString()
            }).ToList();
            return teacherSubjectsList;
        }
    }
}