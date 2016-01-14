using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StudentSystem.Data.Repositories;
using StudentSystem.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Data.UnitOfWork
{
   public class StudentSystemData                                 //Nasledi IstudentSystemData ii definirai repositoryta
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        private IUserStore<ApplicationUser> userStore;

        public StudentSystemData(DbContext context)
        {
            this.dbContext = context;
            this.repositories = new Dictionary<Type, object>();
        }

      
       // Definirane na  repository-ta
        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Mark> Marks
        {
            get { return this.GetRepository<Mark>(); }
        }

        public IRepository<Student> Students
        {
            get { return this.GetRepository<Student>(); }
        }
        public IRepository<StudentClass> StudentClasses
        {
            get { return this.GetRepository<StudentClass>(); }
        }

        public IRepository<Subject> Subjects
        {
            get { return this.GetRepository<Subject>(); }
        }

       //User Store

        public IUserStore<ApplicationUser> UserStore
        {
            get
            {
                if (this.userStore == null)
                {
                    this.userStore = new UserStore<ApplicationUser>(this.dbContext);
                }

                return this.userStore;
            }
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(
                    typeof(T),
                    Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }


    }
}
