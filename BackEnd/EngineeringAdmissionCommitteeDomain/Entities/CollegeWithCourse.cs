using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Entities
{
    public class CollegeWithCourse
    {
        public Guid CollegeWithCourseId { get; set; }
        public Guid CollegeId { get; set; }
        public Guid CourseId { get; set; }
        public string CollegeName { get; set; }
        public string CourseName { get; set; }
        public int AvailableSeat { get; set; }
    }
}
