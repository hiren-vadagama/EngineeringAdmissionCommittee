using EngineeringAdmissionCommitteeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Repositories
{
    public interface IAdmissionRepository
    {
        void StudentAdmission(Admission admission);
        bool IsStudentAdmitted(Guid studentId);
        void GetCollgeCutOffRank();
        IEnumerable<StudentAdmission> GetStudentsAdmissionDetails();
    }
}
