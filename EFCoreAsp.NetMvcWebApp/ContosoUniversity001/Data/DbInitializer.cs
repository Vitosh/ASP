using ContosoUniversity.Models;
using System;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{FirstMidName="Carlson", LastName="On the Roof", EnrollmentDate=DateTime.Parse("2000-01-01")},
                new Student{FirstMidName="Mike", LastName="Green", EnrollmentDate=DateTime.Parse("2001-01-01")},
                new Student{FirstMidName="Jack", LastName="Red", EnrollmentDate=DateTime.Parse("2002-01-01")},
                new Student{FirstMidName="Jill", LastName="Purple", EnrollmentDate=DateTime.Parse("2003-01-01")},
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }

            var courses = new Course[]
            {
                new Course{CourseId=711, Title="VBA", Credits=3},
                new Course{CourseId=712, Title="VBA102", Credits=4},
                new Course{CourseId=713, Title="VB.NET", Credits=3},
                new Course{CourseId=714, Title="C++", Credits=3},
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentId=1, CourseId=711, Grade=Grade.A},
                new Enrollment{StudentId=1, CourseId=712, Grade=Grade.A},
                new Enrollment{StudentId=1, CourseId=713, Grade=Grade.B},
                new Enrollment{StudentId=2, CourseId=711, Grade=Grade.C},
                new Enrollment{StudentId=2, CourseId=712},
                new Enrollment{StudentId=3, CourseId=711},
                new Enrollment{StudentId=3, CourseId=712, Grade=Grade.B},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
        }
    }
}
