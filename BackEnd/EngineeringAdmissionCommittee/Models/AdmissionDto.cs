namespace EngineeringAdmissionCommitteeAPI.Models
{
    public class AdmissionDto
    {
        public Guid AdmissionId { get; set; }
        public Guid StudentId { get; set; }
        public Guid CollegeWithCourseId { get; set; }
        public string CollegeName { get; set; }
        public string CourseName { get; set; }
    }
}
