using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngineeringAdmissionCommitteePersistance.Datamodels
{
    public class StudentModel
    {
        [Key]
        public Guid StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        public string Gender { get; set; }
        [Required]
        public float BoardMark { get; set; }
        [Required]
        public float GujcetMark { get; set; }
        public List<PreferenceCollegeModel> PreferenceColleges { get; set; }
        public MeritModel Merit { get; set; }
        public AdmissionModel  Admission { get; set; }
    }
}
