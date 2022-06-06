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
        IEnumerable<CutOffMeritRank> GetCollgeCutOffRank();
        IEnumerable<CutOffMeritMark> GetCollgeCutOffMark();
        IEnumerable<CollegeVacantSeats> GetPercentageOfVacantSeat();
        IEnumerable<StudentAdmission> GetStudentsAdmissionDetails();
    }
}
