using EngineeringAdmissionCommitteeDomain.Entities;

namespace EngineeringAdmissionCommitteeAPI.Models
{
    public class PreferenceCollegeDto
    {
        public Guid PreferenceId { get; set; }
        public Guid CollegeWithCourseId { get; set; }
        public string CollegeName { get; set; }
        public string CourseName { get; set; }
        public int AvailableSeat { get; set; }
        public int Priority { get; set; }
    }
}
