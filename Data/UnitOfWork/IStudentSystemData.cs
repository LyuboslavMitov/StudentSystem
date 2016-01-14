
namespace StudentSystem.Data.UnitOfWork
{
    using StudentSystem.DatabaseModels;
    using StudentSystem.Data.Repositories;
    public interface IStudentSystemData
    {
        IRepository<ApplicationUser> Users { get; set; }
        void SaveChanges();
    }
}
