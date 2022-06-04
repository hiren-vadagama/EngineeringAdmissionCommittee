using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngineeringAdmissionCommitteePersistance.Datamodels
{
    public class AdmissionModel
    {
        [Key]
        public Guid AdmissionId { get; set; }
        [Required]
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        [Required]
        [ForeignKey("CollegeWithCourse")]
        public Guid CollegeWithCourseId { get; set; }
        public StudentModel Student { get; set; }
        public CollegeWithCourseModel CollegeWithCourse { get; set; }
    }
}
