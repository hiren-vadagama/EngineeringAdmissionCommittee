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
    public class MeritRepository : IMeritRepository
    {
        private readonly EngineeringAdmissionCommitteeContext _context;
        private readonly IMapper _mapper;

        public MeritRepository(EngineeringAdmissionCommitteeContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void GenerateMerit()
        {
            var calculatePercentage = _context.Students.Select(student => new { StudentId=student.StudentId, Percentage = ((student.BoardMark * 0.6) + (student.GujcetMark * 0.4)) })
                                                       .AsEnumerable();

            var maritWithRank = calculatePercentage.OrderByDescending(student => student.Percentage)
                                                   .Select((student, index) => new Merit { StudentId = student.StudentId, Rank= index + 1 });
            DeleteMeritData();

            AddMerit(maritWithRank);
        }

        public void AddMerit(IEnumerable<Merit> merit)
        {
            _context.Merits.AddRange(_mapper.Map<IEnumerable<MeritModel>>(merit));
            Save();
        }

        public void DeleteMeritData()
        {
            _context.Merits.RemoveRange(_context.Merits);
            Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Merit> GetMerits()
        {
            return _mapper.Map<IEnumerable<Merit>>(_context.Merits);
        }

    }
}
