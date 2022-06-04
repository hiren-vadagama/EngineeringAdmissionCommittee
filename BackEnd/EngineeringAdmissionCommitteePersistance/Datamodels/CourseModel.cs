using System.ComponentModel.DataAnnotations;

namespace EngineeringAdmissionCommitteePersistance.Datamodels
{
    public class CourseModel
    {
        [Key]
        public Guid CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public List<CollegeWithCourseModel> CollegeWithCourses { get; set; }
    }
}
