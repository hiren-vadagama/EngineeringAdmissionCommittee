using System.ComponentModel.DataAnnotations;

namespace EngineeringAdmissionCommitteePersistance.Datamodels
{
    public class AdminModel
    {
        [Key]
        public Guid AdminId { get; set; }
        [Required]
        public string AdminName { get; set; }
    }
}
