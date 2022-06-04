using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services.Impl
{
    public class AdminService : IAdminService
    {
        private readonly IStudentService _studentService;
        private readonly IAdminRepository _adminRepository;
        private readonly IAdmissionRepository _admissionRepository;
        private readonly IMaritRepository _maritRepository;
        private readonly ICollegeWithCourseRepository _collegeWithCourseRepository;

        public AdminService(IAdminRepository adminRepository, 
                            IAdmissionRepository admissionRepository, 
                            IMaritRepository maritRepository,
                            IStudentService studentService, 
                            ICollegeWithCourseRepository collegeWithCourseRepository)
        {
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
            _admissionRepository = admissionRepository ?? throw new ArgumentNullException(nameof(admissionRepository));
            _maritRepository = maritRepository ?? throw new ArgumentNullException(nameof(maritRepository));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _collegeWithCourseRepository = collegeWithCourseRepository ?? throw new ArgumentNullException(nameof(collegeWithCourseRepository));
        }
        public void GenerateMarit(Admin admin)
        {
            if(!AdminExists(admin.AdminId))
            {
                throw new ArgumentException("Invalidate admin");
            }

            _maritRepository.GenerateMarit();
        }

        public bool AdminExists(Guid adminId)
        {
            if(adminId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(adminId));
            }

            return _adminRepository.AdminExists(adminId);
        }

        public void StudentAdmission(Guid studentId)
        {
            var student = _studentService.GetStudentWithPreferenceColleges(studentId);
            var preferences = student.PreferenceColleges.OrderBy(preference => preference.Priority)
                                                        .Where(preference => preference.AvailableSeat > 0).First();

            _collegeWithCourseRepository.DecreaseAvailableSeat(preferences.CollegeWithCourseId);
            
        }
    }
}
