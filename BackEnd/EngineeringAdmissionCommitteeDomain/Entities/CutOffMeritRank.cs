using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Entities
{
    public class CutOffMeritRank
    {
        public Guid CollegeWithCourseId { get; set; }
        public int Rank { get; set; }
    }
}
