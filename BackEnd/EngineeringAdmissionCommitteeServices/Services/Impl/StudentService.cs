using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services.Impl
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public IEnumerable<Student> GetAllStudentsWithPreferences()
        {
            return _studentRepository.GetAllStudentsWithPreferences();
        }

        public Student GetStudentDetailsByStudentId(Guid studentId)
        {
            if(!isStudentExists(studentId))
            {
                throw new ArgumentException("Student does not exist");
            }

            return _studentRepository.GetStudentDetailsByStudentId(studentId);
        }

        public Student GetStudentWithPreferenceColleges(Guid studentId)
        {
            if (!isStudentExists(studentId))
            {
                throw new ArgumentException("Student does not exist");
            }

            return _studentRepository.GetStudentWithPreferenceColleges(studentId);
        }
        public void AddStudent(Student newStudent)
        {
            if(newStudent.PreferenceColleges.Count!=5)
            {
                throw new ArgumentException("Preference for colleges & courses must have 5 entries");
            }

            if(isPriorityInvalid(newStudent.PreferenceColleges))
            {
                throw new ArgumentException("Priority for preferences must between 1 to 5");
            }

            _studentRepository.AddStudent(newStudent);
        }

        public bool isStudentExists(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentException(nameof(studentId));
            }

            return _studentRepository.StudentExists(studentId);
        }

        public bool isPriorityInvalid(List<PreferenceCollege> preferenceCollege)
        {
            return preferenceCollege.Any(preference => preference.Priority < 1 || preference.Priority>5);
        }
    }
}
