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
     /* При първоначално стартиране на системата се изпълнява първоначално запълване на базата с данни (т.нар seed),
        включващo регистриране и профил на поне един администратор*/
        protected override void Seed(StudentSystem.Data.ApplicationDbContext context)
        {

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
                    Number = 25,
                    StudentClass = cls
                };
                var stud1 = new Student
                {
                    FirstName = "Lyuboslav",
                    SecondName = "J.",
                    LastName = " Mitov",
                    Number = 15,
                    StudentClass = cls1
                };
                var stud2 = new Student
                {
                    FirstName = "Stoil",
                    SecondName = "J.",
                    LastName = " Yankov",
                    Number = 22,
                    StudentClass = cls1
                };
                var stud3 = new Student
                {
                    FirstName = "Marin",
                    SecondName = "J.",
                    LastName = " Karadjov",
                    Number = 16,
                    StudentClass = cls1
                };
                context.Students.Add(stud);
                context.Students.Add(stud1);
                context.Students.Add(stud2);
                context.Students.Add(stud3);
                context.SaveChanges();
                
                if (!context.Users.Any(u => u.UserName == "admin@mail.com"))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    var admin = new ApplicationUser
                    {
                        UserName = "admin@mail.com",
                        Email = "admin@mail.com",
                        PhoneNumber="0883422356"
                    };

                   
                    manager.Create(admin, "admin123");
                   
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
