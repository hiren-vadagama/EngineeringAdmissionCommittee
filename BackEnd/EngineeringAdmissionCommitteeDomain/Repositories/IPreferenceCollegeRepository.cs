using EngineeringAdmissionCommitteeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Repositories
{
    public interface IPreferenceCollegeRepository
    {
       Student GetStudentWithPreferenceColleges(Guid StudentId);
    }
}
