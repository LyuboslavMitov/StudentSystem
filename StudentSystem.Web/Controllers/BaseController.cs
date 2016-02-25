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
            var teacherClasses = this.data.Users.Find(id).StudentClasses.ToList();
            var teacherClassesSelectList = this.data.StudentClasses.All().ToList().Select(x => new SelectListItem
            {
                Text = x.ClassName,
                Value = x.StudentClassID.ToString(),
                Selected = teacherClasses.Any(c => c.StudentClassID == x.StudentClassID)
            }).ToList();

            return teacherClassesSelectList;
    }

        protected List<SelectListItem> TeacherSubjectsList(string id)
        {
            var teacherSubjects = this.data.Users.Find(id).Subjects.ToList();
            var teacherSubjectsList = this.data.Subjects.All().ToList().Select(x => new SelectListItem
            {
                Text = x.SubjectName,
                Value = x.SubjectID.ToString(),
                Selected = teacherSubjects.Any(c => c.SubjectID == x.SubjectID)
            }).ToList();
            return teacherSubjectsList;
        }
    }
}