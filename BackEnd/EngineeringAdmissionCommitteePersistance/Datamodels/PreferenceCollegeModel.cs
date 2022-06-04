using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngineeringAdmissionCommitteePersistance.Datamodels
{
    public class PreferenceCollegeModel
    {
        [Key]
        public Guid PreferenceId { get; set; }
        [Required]
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        [Required]
        [ForeignKey("CollegeWithCourse")]
        public Guid CollegeWithCourseId { get; set; }
        public StudentModel Student { get; set; }
        public CollegeWithCourseModel CollegeWithCourse { get; set; }
        [Required]
        public int Priority { get; set; }
    }
}
