using EngineeringAdmissionCommitteeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Repositories
{
    public interface ICollegeWithCourseRepository
    {
        void AllocateSeat(Guid collegeWithCourseId);
        IEnumerable<CollegeWithCourse> GetAllCollgeWithCourses();
        IEnumerable<College> GetAllCollegesDetails();
        IEnumerable<Course> GetCoursesByCollegeId(Guid collegeId);
    }
}
