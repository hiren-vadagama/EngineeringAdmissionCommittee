using EngineeringAdmissionCommitteeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services
{
    public interface IMeritService
    {
        void GenerateMarit(Admin admin);
        IEnumerable<Merit> GetMerits();
    }
}
