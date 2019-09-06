using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstMidName = "Joe",   LastName = "Banana",
                    EnrollmentDate = DateTime.Parse("2010-01-01") },
                new Student { FirstMidName = "Sofia", LastName = "Berlin",
                    EnrollmentDate = DateTime.Parse("2012-01-01") },
                new Student { FirstMidName = "Silistra",   LastName = "Busters",
                    EnrollmentDate = DateTime.Parse("2013-01-01") },
                new Student { FirstMidName = "Ivan",    LastName = "B.",
                    EnrollmentDate = DateTime.Parse("2012-01-01") },
                new Student { FirstMidName = "Mina",    LastName = "Batman",
                    EnrollmentDate = DateTime.Parse("2011-01-01") },
                new Student { FirstMidName = "Pesho",    LastName = "Zorro",
                    EnrollmentDate = DateTime.Parse("2013-01-01") },
                new Student { FirstMidName = "Hristomir",     LastName = "Hristov",
                    EnrollmentDate = DateTime.Parse("2005-01-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstMidName = "Krachun",     LastName = "Malchov",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstMidName = "Safadi",    LastName = "Yordanov",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstMidName = "Hristo",   LastName = "Stoichkov",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstMidName = "Yordan", LastName = "Lechkov",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstMidName = "Hristo",   LastName = "Zhabov",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Advanced Design",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Malchov").ID },
                new Department { Name = "Design", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Yordanov").ID },
                new Department { Name = "Advanced Structures", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Stoichkov").ID },
                new Department { Name = "Advanced Programming",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorId  = instructors.Single( i => i.LastName == "Lechkov").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseId = 1050, Title = "General Programming",      Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Structures").DepartmentId
                },
                new Course {CourseId = 4022, Title = "Programming 101", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Programming").DepartmentId
                },
                new Course {CourseId = 4041, Title = "Programming 201", Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Programming").DepartmentId
                },
                new Course {CourseId = 1045, Title = "Algorithms",       Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Design").DepartmentId
                },
                new Course {CourseId = 3141, Title = "Front End",   Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Design").DepartmentId
                },
                new Course {CourseId = 2021, Title = "Back End",    Credits = 3,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Design").DepartmentId
                },
                new Course {CourseId = 2042, Title = "CSS",     Credits = 4,
                    DepartmentId = departments.Single( s => s.Name == "Advanced Design").DepartmentId
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Yordanov").ID,
                    Location = "Nuremberg" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Stoichkov").ID,
                    Location = "Sofia" },
                new OfficeAssignment {
                    InstructorId = instructors.Single( i => i.LastName == "Lechkov").ID,
                    Location = "Silistra" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "General Programming" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Lechkov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "General Programming" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Stoichkov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Programming 101" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Zhabov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Programming 201" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Zhabov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Algorithms" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Yordanov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Front End" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Stoichkov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "Back End" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Malchov").ID
                    },
                new CourseAssignment {
                    CourseId = courses.Single(c => c.Title == "CSS" ).CourseId,
                    InstructorId = instructors.Single(i => i.LastName == "Malchov").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Banana").Id,
                    CourseId = courses.Single(c => c.Title == "General Programming" ).CourseId,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Banana").Id,
                    CourseId = courses.Single(c => c.Title == "Programming 101" ).CourseId,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Banana").Id,
                    CourseId = courses.Single(c => c.Title == "Programming 201" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Berlin").Id,
                    CourseId = courses.Single(c => c.Title == "Algorithms" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Berlin").Id,
                    CourseId = courses.Single(c => c.Title == "Front End" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Berlin").Id,
                    CourseId = courses.Single(c => c.Title == "Back End" ).CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Busters").Id,
                    CourseId = courses.Single(c => c.Title == "General Programming" ).CourseId
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Busters").Id,
                    CourseId = courses.Single(c => c.Title == "Programming 101").CourseId,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentId = students.Single(s => s.LastName == "B.").Id,
                    CourseId = courses.Single(c => c.Title == "General Programming").CourseId,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentId = students.Single(s => s.LastName == "Batman").Id,
                    CourseId = courses.Single(c => c.Title == "CSS").CourseId,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.Id == e.StudentId &&
                            s.Course.CourseId == e.CourseId).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
