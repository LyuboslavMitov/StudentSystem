
namespace StudentSystem.Data.UnitOfWork
{
    using StudentSystem.DatabaseModels;
    using StudentSystem.Data.Repositories;
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
