using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services
{
    public interface IAdmissionService
    {
        void AdmissionByPreference(Guid studentId);
        void AdmissionByCollegeWithCourseId(Guid studentId, Guid collegeWithCourseId);
    }
}
