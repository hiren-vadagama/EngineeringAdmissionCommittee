using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Entities
{
    public class PreferenceCollege
    {
        public Guid PreferenceId { get; set; }
        public Guid CollegeWithCourseId { get; set; }
        public string CollegeName { get; set; }
        public string CourseName { get; set; }
        public int AvailableSeat { get; set; }
        public int Priority { get; set; }
    }
}
