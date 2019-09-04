using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name= "Number")]
        public int CourseId { get; set; }

        [StringLength(50,MinimumLength = 1)]
        public string Title { get; set; }

        [Range(0,10)]
        public int Credits  { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments{ get; set; }
        public ICollection<CourseAssignment>CourseAssignments{ get; set; }
    }
}
