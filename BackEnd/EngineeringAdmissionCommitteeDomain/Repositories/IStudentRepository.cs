using EngineeringAdmissionCommitteeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentDetailsByStudentId(Guid studentId);
        void AddStudent(Student newStudent);
        bool StudentExists(Guid studentId);
        IEnumerable<Student> GetAllStudentsWithPreferences();
        Student GetStudentWithPreferenceColleges(Guid StudentId);
    }
}
