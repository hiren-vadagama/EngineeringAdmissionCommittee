using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services.Impl
{
    public class CollegeWithCourseService : ICollegeWithCourseService
    {
        private readonly ICollegeWithCourseRepository _collegeWithCourseRepository;

        public CollegeWithCourseService(ICollegeWithCourseRepository collegeWithCourseRepository)
        {
            _collegeWithCourseRepository = collegeWithCourseRepository ?? throw new ArgumentNullException(nameof(collegeWithCourseRepository));
        }

        public IEnumerable<College> GetAllCollegesDetails()
        {
            return _collegeWithCourseRepository.GetAllCollegesDetails();
        }

        public IEnumerable<CollegeWithCourse> GetAllCollgeWithCourses()
        {
            return _collegeWithCourseRepository.GetAllCollgeWithCourses();
        }

        public IEnumerable<Course> GetCoursesByCollegeId(Guid collegeId)
        {
            return _collegeWithCourseRepository.GetCoursesByCollegeId(collegeId);
        }
    }
}
