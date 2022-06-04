using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public float BoardMark { get; set; }
        public float GujcetMark { get; set; }
        public List<PreferenceCollege> PreferenceColleges { get; set; }
        public Merit Merit { get; set; }
        public Admission Admission { get; set; }
    }
}
