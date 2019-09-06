using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {
        }
        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
        {
        }
        public DbSet <Course> Courses { get; set; }
        public DbSet <Enrollment> Enrollments { get; set; }
        public DbSet <Student> Students { get; set; }
        public DbSet <Department> Departments { get; set; }
        public DbSet <Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments{ get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Cursos");
            modelBuilder.Entity<Enrollment>().ToTable("Inscriptiones");
            modelBuilder.Entity<Student>().ToTable("Estudiantes");
            modelBuilder.Entity<Department>().ToTable("Departamentos");
            modelBuilder.Entity<Instructor>().ToTable("Instructores");
            modelBuilder.Entity<OfficeAssignment>().ToTable("AsignacionesDeOficina");
            modelBuilder.Entity<CourseAssignment>().ToTable("AsignacionesDeCurso");

            modelBuilder.Entity<CourseAssignment>()
                    .HasKey(c => new { c.CourseId, c.InstructorId });

        }
    }
}
