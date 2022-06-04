using EngineeringAdmissionCommitteeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentWithPreferenceColleges(Guid studentId);
        public Student GetStudentDetailsByStudentId(Guid studentId);
        public void AddStudent(Student newStudent);
        public IEnumerable<Student> GetAllStudentsWithPreferences();
    }
}
