
namespace StudentSystem.Data
{
    using StudentSystem.DatabaseModels;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IApplicationDbContext
    {
        IDbSet<Mark> Marks { get; set; }
        IDbSet<Student> Students { get; set; }
        IDbSet<StudentClass> StudentClasses { get; set; }
        IDbSet<Subject> Subjects { get; set; }
        IDbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
