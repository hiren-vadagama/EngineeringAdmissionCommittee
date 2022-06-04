using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Entities
{
    public class CutOffMeritMark
    {
        public Guid CollegeWithCourseId { get; set; }
        public float BoardMark { get; set; }
        public float GujcetMark { get; set; }
    }
}
