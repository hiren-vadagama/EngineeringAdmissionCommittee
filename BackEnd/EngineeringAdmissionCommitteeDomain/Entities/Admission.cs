using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Entities
{
    public class Admission
    {
        public Guid AdmissionId { get; set; }
        public Guid StudentId { get; set; }
        public Guid CollegeWithCourseId { get; set; }
        public string CollegeName { get; set; }
        public string CourseName { get; set; }
    }
}
