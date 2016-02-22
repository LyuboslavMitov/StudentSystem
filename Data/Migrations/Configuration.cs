namespace StudentSystem.Data.Migrations
{
    using StudentSystem.DatabaseModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled =true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystem.Data.ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplica9te seed data. E.g.
            //
            if(!context.StudentClasses.Any(c=>c.ClassName == "11A"))
            {

                var sub = new Subject { SubjectName = "Информатика" };
                context.Subjects.Add(sub);
                var cls = new StudentClass { ClassName = "11A" };
                var cls2 = new StudentClass { ClassName = "10A" };
                var cls1 = new StudentClass { ClassName = "12A" };
                context.StudentClasses.Add(cls);
                context.StudentClasses.Add(cls1);
                context.StudentClasses.Add(cls2);

                var stud = new Student
                {
                    FirstName = "Andrew",
                    SecondName = "J.",
                    LastName = " Peters",
                    Number = 1234567,
                    StudentClass = cls
                };
                var stud1 = new Student
                {
                    FirstName = "Lyuboslav",
                    SecondName = "J.",
                    LastName = " Mitov",
                    Number = 123456,
                    StudentClass = cls
                };
                var stud2 = new Student
                {
                    FirstName = "Stoil",
                    SecondName = "J.",
                    LastName = " Yankov",
                    Number = 12345,
                    StudentClass = cls
                };
                var stud3 = new Student
                {
                    FirstName = "Stoil",
                    SecondName = "J.",
                    LastName = " Takoata",
                    Number = 12345,
                    StudentClass = cls
                };
                context.Students.Add(stud);
                context.Students.Add(stud1);
                context.Students.Add(stud2);
                context.Students.Add(stud3);
                context.SaveChanges();
                
                if (!context.Users.Any(u => u.UserName == "deevvil_pz@abv.bg"))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    var user = new ApplicationUser
                    {
                        UserName = "deevvil_pz@abv.bg",
                        Email = "deevvil_pz@abv.bg",
                        PhoneNumber = "0889862464",
                        
                    };

                   
                    manager.Create(user, "123asd");
                   
                }
                if (!context.Users.Any(u => u.UserName == "teacher@abv.bg"))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    

                    var teacher = new ApplicationUser
                    {
                        UserName = "teacher@abv.bg",
                        Email = "teacher@abv.bg",
                        PhoneNumber = "0889862464",
                        
                    };
                    teacher.StudentClasses.Add(cls);
                    teacher.Subjects.Add(sub);
                    manager.Create(teacher, "123asd");
                    

                }
                
            }
        }
    }
}
