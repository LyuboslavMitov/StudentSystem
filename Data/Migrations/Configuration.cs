namespace StudentSystem.Data.Migrations
{
    using StudentSystem.DatabaseModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
                    EGN = "1234567890",
                    Number = 1234567,
                    StudentClass = cls
                };
                context.Students.Add(stud);
                context.SaveChanges();
            }
        }
    }
}
