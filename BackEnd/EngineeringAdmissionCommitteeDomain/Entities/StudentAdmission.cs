using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Entities
{
    public class StudentAdmission
    {
        public Guid StudentId { get; set; }
        public float BoardMark { get; set; }
        public float GujcetMark { get; set; }
        public int Rank { get; set; }
        public Guid CollegeWithCourseId { get; set; }
    }
}
