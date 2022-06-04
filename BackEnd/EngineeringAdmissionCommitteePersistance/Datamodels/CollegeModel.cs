using System.ComponentModel.DataAnnotations;

namespace EngineeringAdmissionCommitteePersistance.Datamodels
{
    public class CollegeModel
    {
        [Key]
        public Guid CollegeId { get; set; }
        [Required]
        public string CollegeName { get; set; }
        public List<CollegeWithCourseModel> CollegeWithCourses { get; set; }
    }
}
