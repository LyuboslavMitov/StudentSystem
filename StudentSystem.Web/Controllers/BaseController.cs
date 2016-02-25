using StudentSystem.Data.UnitOfWork;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Microsoft.AspNet.Identity;

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
        private ApplicationUser GetCurrentUser()
        {
            string userId = this.User.Identity.GetUserId();
            var user = this.data.Users.All().FirstOrDefault(u => u.Id == userId);
            return user;
        }

       // protected ApplicationUser CurrentUser { get; set; }
        protected ApplicationUser CurrentUser
        {
            get
            {
                string userId = this.User.Identity.GetUserId();
                var user = this.data.Users.All().FirstOrDefault(u => u.Id == userId);
                return user;
            }
        }
    }
}