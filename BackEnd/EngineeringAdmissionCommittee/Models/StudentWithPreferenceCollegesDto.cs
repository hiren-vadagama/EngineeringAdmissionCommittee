
namespace EngineeringAdmissionCommitteeAPI.Models
{
    public class StudentWithPreferenceCollegesDto
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public float BoardMark { get; set; }
        public float GujcetMark { get; set; }
        public List<PreferenceCollegeDto> PreferenceColleges { get; set; }
    }
}
