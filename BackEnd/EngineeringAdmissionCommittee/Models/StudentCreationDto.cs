namespace EngineeringAdmissionCommitteeAPI.Models
{
    public class StudentCreationDto
    {
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public float BoardMark { get; set; }
        public float GujcetMark { get; set; }
        public List<PreferenceCollegeCreationDto> PreferenceColleges { get; set; }
    }
}
