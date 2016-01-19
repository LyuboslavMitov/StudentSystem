using StudentSystem.DatabaseModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StudentSystem.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> , IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public IDbSet<Mark> Marks { get; set; }
        public IDbSet<Student> Students { get; set; }
        public IDbSet<StudentClass> StudentClasses { get; set; }
        public IDbSet<Subject> Subjects { get; set; }
    }
}

