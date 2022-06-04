using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EngineeringAdmissionCommitteePersistance.Datamodels
{
    public class MeritModel
    {
        [Key]
        public Guid MeritId { get; set; }
        [Required]
        public int Rank { get; set; }

        [Required]
        [ForeignKey("Student")]
        public Guid StudentId { get; set; }
        public StudentModel Student { get; set; }
    }
}
