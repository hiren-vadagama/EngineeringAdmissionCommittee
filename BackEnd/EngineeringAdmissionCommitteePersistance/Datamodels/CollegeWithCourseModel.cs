using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteePersistance.Datamodels
{
    public class CollegeWithCourseModel
    {
        [Key]
        public Guid CollegeWithCourseId { get; set; }
        [Required]
        [ForeignKey("College")]
        public Guid CollegeId { get; set; }
        [Required]
        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public CollegeModel College { get; set; }
        public CourseModel Course { get; set; }
        [Required]
        public int AvailableSeat { get; set; }
        public int TotalSeat { get; set; }
    }
}
