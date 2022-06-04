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
    public class CollegeWithCourseRepository : ICollegeWithCourseRepository
    {
        private readonly EngineeringAdmissionCommitteeContext _context;
        private readonly IMapper _mapper;

        public CollegeWithCourseRepository(EngineeringAdmissionCommitteeContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void AllocateSeat(Guid collegeWithCourseId)
        {
            var collegeWithCourse = _context.CollegeWithCourses.Where(collegeWithCourse => collegeWithCourse.CollegeWithCourseId == collegeWithCourseId)
                                                               .First();
            collegeWithCourse.AvailableSeat--;
            _context.CollegeWithCourses.Update(_mapper.Map<CollegeWithCourseModel>(collegeWithCourse));
            Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<CollegeWithCourse> GetAllCollgeWithCourses()
        {
            return _mapper.Map<IEnumerable<CollegeWithCourse>>(_context.CollegeWithCourses.Include(collegeWithCourses => collegeWithCourses.College)
                                                                                          .Include(collegeWithCourse => collegeWithCourse.Course));
        }

        public IEnumerable<College> GetAllCollegesDetails()
        {
            return _mapper.Map<IEnumerable<College>>(_context.Colleges);
        }

        public IEnumerable<Course> GetCoursesByCollegeId(Guid collegeId)
        {
            var college = _context.Colleges.Where(college => college.CollegeId == collegeId)
                                          .Include(college => college.CollegeWithCourses)
                                            .ThenInclude(college => college.Course)
                                          .First();

            return _mapper.Map<IEnumerable<Course>>(college.CollegeWithCourses.Select(course => course.Course));
        }
    }
}
