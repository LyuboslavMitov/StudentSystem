namespace StudentSystem.Data.Migrations
{
    using StudentSystem.DatabaseModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

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
                //context.Students.Add(new Student());
                //context.SaveChanges();
                var cls = new StudentClass { ClassName = "11A" };
                context.StudentClasses.Add(cls);

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
                context.Students.Add(stud);
                context.Students.Add(stud1);
                context.Students.Add(stud2);
                context.SaveChanges();
                if (!context.Users.Any(u => u.UserName == "deevvil_pz@abv.bg"))
                {
                    var user = new ApplicationUser
                    {
                        UserName = "deevvil_pz@abv.bg",
                        Email = "deevvil_pz@abv,bg",
                        PhoneNumber = "0889862464",
                        
                    };
                }
            }
        }
    }
}
