using EngineeringAdmissionCommitteeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services
{
    public interface ICollegeWithCourseService
    {
        IEnumerable<CollegeWithCourse> GetAllCollgeWithCourses();
        IEnumerable<Course> GetCoursesByCollegeId(Guid collegeId);
        IEnumerable<College> GetAllCollegesDetails();
    }
}
