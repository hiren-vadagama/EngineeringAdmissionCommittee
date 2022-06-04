namespace EngineeringAdmissionCommitteeAPI.Models
{
    public class CollegeWithCourseDto
    {
        public Guid CollegeWithCourseId { get; set; }
        public Guid CollegeId { get; set; }
        public Guid CourseId { get; set; }
        public string CollegeName { get; set; }
        public string CourseName { get; set; }
        public int AvailableSeat { get; set; }
    }
}
