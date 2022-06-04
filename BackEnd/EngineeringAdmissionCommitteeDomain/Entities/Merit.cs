using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Entities
{
    public class Merit
    {
        public Guid MeritId { get; set; }
        public int Rank { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
