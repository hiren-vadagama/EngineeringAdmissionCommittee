using AutoMapper;
using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeDomain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteePersistance.Repositories
{
    public class PreferenceCollegeRepository : IPreferenceCollegeRepository
    {
        private readonly EngineeringAdmissionCommitteeContext _context;
        private readonly IMapper _mapper;

        public PreferenceCollegeRepository(EngineeringAdmissionCommitteeContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
    }
}
