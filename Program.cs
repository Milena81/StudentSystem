namespace StudentSystem
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Random random = new Random();

        public static void Main()
        {
            using (var db = new StudentSystemDbContext())
            {
                db.Database.Migrate();

                SeedData(db);
            }
        }

        private static void SeedData(StudentSystemDbContext db)
        {
            //to fill some data in DB, we use for loop

            const int totalStudents = 25;
            const int totalCourses = 10;
            var currentDate = DateTime.Now;

            //Students
            for (int i = 0; i < totalStudents; i++)
            {
                db.Students.Add(new Student
                {
                    Name = $"Student {i}",
                    RegistrationDate = currentDate.AddDays(i),
                    Birthday = currentDate.AddYears(-20).AddDays(i),
                    Phone = $"Random Phone {i}"
                });
            }

            db.SaveChanges();

            //Courses
            var addedCourses = new List<Course>();

            for (int i = 0; i < totalCourses; i++)
            {
                var course = new Course
                {
                    Name = $"Course {i}",
                    Description = $"Course Details {i}",
                    Price = 100 * i,
                    StartDate = currentDate.AddDays(i),
                    EndDate = currentDate.AddDays(20 + i)
                };

                addedCourses.Add(course);

                db.Courses.Add(course);
            }

            db.SaveChanges();

            //Students in Courses
            var studentIds = db
                        .Students
                        .Select(s => s.Id)
                        .ToList();

            for (int i = 0; i < totalCourses; i++)
            {
                var currentCourse = addedCourses[i];

                var studentsInCourse = random.Next(2, totalStudents / 2);

                for (int j = 0; j < studentsInCourse; j++)
                {
                    var studentId = studentIds[random.Next(0, studentIds.Count)];

                    currentCourse.Students.Add(new StudentCourse
                    {
                        StudentId = studentId,
                    });
                }
            }

            db.SaveChanges();
        }
    }
}
