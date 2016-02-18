using StudentSystem.DatabaseModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentSystem.Data.Migrations;


namespace StudentSystem.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> , IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("StudentSystem", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public IDbSet<Mark> Marks { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<StudentClass> StudentClasses { get; set; }
        public IDbSet<Subject> Subjects { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

       

       // public System.Data.Entity.DbSet<StudentSystem.Web.Models.AdminStudentViewModel> AdminStudentViewModels { get; set; }


       //  protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
       // {
       //     modelBuilder.Entity<Mark>().HasKey(i => new { i.TeacherID,i.StudentID , i.SubjectID, i.StudentClassID });


       //     modelBuilder.Entity<Mark>()
       // .HasRequired(i => i.Teacher)                        //Teacher
       // .WithMany()
       // .HasForeignKey(i => i.TeacherID);


       //     modelBuilder.Entity<Mark>()
       //.HasRequired(i => i.Subject)
       //.WithMany()                                          // Subject
       //.HasForeignKey(i => i.SubjectID);


       //     modelBuilder.Entity<Mark>()
       //.HasRequired(i => i.Student)
       //.WithMany()                                          //Student
       //.HasForeignKey(i => i.StudentID);


       //     modelBuilder.Entity<Mark>()
       //.HasRequired(i => i.StudentClass)
       //.WithMany()                                          //CLASS
       //.HasForeignKey(i => i.StudentClassID);

        

        }
    }


