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
    public class MaritRepository : IMaritRepository
    {
        private readonly EngineeringAdmissionCommitteeContext _context;
        private readonly IMapper _mapper;

        public MaritRepository(EngineeringAdmissionCommitteeContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void GenerateMarit()
        {
            var calculatePercentage = _context.Students.Select(student => new { StudentId=student.StudentId, Percentage = ((student.BoardMark * 0.6) + (student.GujcetMark * 0.4)) })
                                                       .AsEnumerable();

            var maritWithRank = calculatePercentage.OrderByDescending(student => student.Percentage)
                                                   .Select((student, index) => new Marit { StudentId = student.StudentId, Rank= index + 1 });

            _context.Marits.RemoveRange(_context.Marits);

            _context.Marits.AddRange(_mapper.Map<IEnumerable<MaritModel>>(maritWithRank));

            Save();
        }
        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
