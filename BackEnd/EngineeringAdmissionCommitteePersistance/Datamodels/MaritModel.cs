using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngineeringAdmissionCommitteePersistance.Datamodels
{
    public class MaritModel
    {
        [Key]
        public Guid MaritId { get; set; }
        [Required]
        public int Rank { get; set; }

        [Required]
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        public StudentModel Student { get; set; }
    }
}
