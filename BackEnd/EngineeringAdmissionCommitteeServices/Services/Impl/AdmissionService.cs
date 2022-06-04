using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services.Impl
{
    public class AdmissionService : IAdmissionService
    {
        private readonly IAdmissionRepository _admissionRepository;
        private readonly ICollegeWithCourseRepository _collegeWithCourseRepository;
        private readonly IStudentService _studentService;

        public AdmissionService(IAdmissionRepository admissionRepository,
                                ICollegeWithCourseRepository collegeWithCourseRepository,
                                IStudentService studentService)
        {
            _admissionRepository = admissionRepository ?? throw new ArgumentNullException(nameof(admissionRepository));
            _collegeWithCourseRepository = collegeWithCourseRepository ?? throw new ArgumentNullException(nameof(collegeWithCourseRepository));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        public void AdmissionByPreference(Guid studentId)
        {
            if (IsStudentAdmitted(studentId))
            {
                throw new ArgumentException("Student already admitted");
            }

            var student = _studentService.GetStudentWithPreferenceColleges(studentId);
            var preferences = student.PreferenceColleges.Where(preference => preference.AvailableSeat > 0).First();

            if (preferences == null)
            {
                throw new ArgumentException("All preference colleges seats are filled");
            }

            _collegeWithCourseRepository.AllocateSeat(preferences.CollegeWithCourseId);

            var admission = new Admission() { StudentId = studentId, CollegeWithCourseId = preferences.CollegeWithCourseId };
            _admissionRepository.StudentAdmission(admission);
        }

        public void AdmissionByCollegeWithCourseId(Guid studentId, Guid collegeWithCourseId)
        {
            if (IsStudentAdmitted(studentId))
            {
                throw new ArgumentException("Student already admitted");
            }

            _collegeWithCourseRepository.AllocateSeat(collegeWithCourseId);

            var admission = new Admission() { StudentId = studentId, CollegeWithCourseId = collegeWithCourseId };
            _admissionRepository.StudentAdmission(admission);
        }

        public bool IsStudentAdmitted(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            return _admissionRepository.IsStudentAdmitted(studentId);
        }
    }
}
