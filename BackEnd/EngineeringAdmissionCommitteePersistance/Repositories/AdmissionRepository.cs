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

        public void GetCollgeCutOffRank()
        {
            
        }
    }
}
