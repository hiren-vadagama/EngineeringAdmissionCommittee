using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Entities
{
    public class CollegeVacantSeats
    {
        public Guid CollegeWithCourseId { get; set; }
        public float PerOfVacantSeats { get; set; }
    }
}
