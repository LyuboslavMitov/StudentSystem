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

       

      
        }
    }


