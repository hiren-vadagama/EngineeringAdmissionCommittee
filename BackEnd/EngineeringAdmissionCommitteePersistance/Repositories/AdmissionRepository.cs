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
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly EngineeringAdmissionCommitteeContext _context;
        private readonly IMapper _mapper;

        public AdmissionRepository(EngineeringAdmissionCommitteeContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void StudentAdmission(Admission admission)
        {
            _context.Admissions.Add(_mapper.Map<AdmissionModel>(admission));
            Save();
        }

        public bool IsStudentAdmitted(Guid studentId)
        {
            return _context.Admissions.Any(admission => admission.StudentId == studentId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<StudentAdmission> GetStudentsAdmissionDetails()
        {
            return _mapper.Map<IEnumerable<StudentAdmission>>(_context.Admissions.Include(admission => admission.Student)
                .ThenInclude(student => student.Merit));
        }

        public IEnumerable<CutOffMeritRank> GetCollgeCutOffRank()
        {
            return _context.Admissions.Include(admission => admission.Student)
                                    .ThenInclude(student => student.Merit)
                                    .GroupBy(college => college.CollegeWithCourseId)
                                    .Select(student => new CutOffMeritRank { CollegeWithCourseId = student.Key, Rank = student.Max(x => x.Student.Merit.Rank) });
        }

        public IEnumerable<CutOffMeritMark> GetCollgeCutOffMark()
        {
            return _context.Admissions.Include(admission => admission.Student)
                                    .GroupBy(college => college.CollegeWithCourseId)
                                    .Select(student => new CutOffMeritMark
                                    {
                                        CollegeWithCourseId = student.Key,
                                        BoardMark = student.Min(x => x.Student.BoardMark),
                                        GujcetMark = student.Min(x => x.Student.GujcetMark)
                                    });
        }

        public IEnumerable<CollegeVacantSeats> GetPercentageOfVacantSeat()
        {
            return _context.CollegeWithCourses
                                    .Select(student => new CollegeVacantSeats
                                    {
                                        CollegeWithCourseId = student.CollegeWithCourseId,
                                        PerOfVacantSeats = student.AvailableSeat * 100 / student.TotalSeat
                                    });
        }
    }
}
