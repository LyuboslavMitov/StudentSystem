
namespace StudentSystem.Data.UnitOfWork
{
    using StudentSystem.DatabaseModels;
    using StudentSystem.Data.Repositories;
   //дефинирани са всички Repository обекти за обмен на данни, както и метод за запис на състоянието на DbContext-а
    public interface IStudentSystemData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Mark> Marks { get; }
        IRepository<Student> Students { get; }
        IRepository<StudentClass> StudentClasses { get; }
        IRepository<Subject> Subjects { get; }

        void SaveChanges();
    }
}
