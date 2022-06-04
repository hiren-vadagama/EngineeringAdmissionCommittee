using AutoMapper;
using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeDomain.Repositories;
using EngineeringAdmissionCommitteePersistance.Datamodels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteePersistance.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EngineeringAdmissionCommitteeContext _context;
        private readonly IMapper _mapper;

        public StudentRepository(EngineeringAdmissionCommitteeContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _mapper.Map<IEnumerable<Student>>(_context.Students);
        }

        public IEnumerable<Student> GetAllStudentsWithPreferences()
        {
            return _mapper.Map<IEnumerable<Student>>(_context.Students.Include(student => student.PreferenceColleges)
                                                                        .ThenInclude(preference => preference.CollegeWithCourse)
                                                                            .ThenInclude(collegeWithCourse => collegeWithCourse.College)
                                                                      .Include(student => student.PreferenceColleges)
                                                                        .ThenInclude(preference => preference.CollegeWithCourse)
                                                                            .ThenInclude(collegeWithCourse => collegeWithCourse.Course));
        }

        public Student GetStudentWithPreferenceColleges(Guid StudentId)
        {
            var studentWithPreference = _context.Students.Where(student => student.StudentId == StudentId)
                                        .Include(student => student.PreferenceColleges.OrderBy(preference => preference.Priority)).
                                            ThenInclude(preference => preference.CollegeWithCourse)
                                                .ThenInclude(collegeWithCourse => collegeWithCourse.College)
                                        .Include(student => student.PreferenceColleges).
                                            ThenInclude(preference => preference.CollegeWithCourse)
                                                .ThenInclude(collegeWithCourse => collegeWithCourse.Course)
                                        .First();

            return _mapper.Map<Student>(studentWithPreference);
        }

        public void AddStudent(Student newStudent)
        {
            newStudent.StudentId = Guid.NewGuid();
            _context.Students.Add(_mapper.Map<StudentModel>(newStudent));
            Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public Student GetStudentDetailsByStudentId(Guid studentId)
        {
            return _mapper.Map<Student>(_context.Students.Where(student => student.StudentId==studentId).FirstOrDefault());
        }

        public bool StudentExists(Guid studentId)
        {
            return _context.Students.Any(student => student.StudentId == studentId);
        }
    }
}
