using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services.Impl
{
    public class ReportService : IReportService
    {
        private readonly IMeritRepository _meritRepository;
        private readonly IAdmissionRepository _admissionRepository;

        public ReportService(IMeritRepository meritRepository,
                             IAdmissionRepository admissionRepository)
        {
            _meritRepository = meritRepository ?? throw new ArgumentNullException(nameof(meritRepository));
            _admissionRepository = admissionRepository ?? throw new ArgumentNullException(nameof(admissionRepository));
        }

        public IEnumerable<CutOffMeritRank> GetCutOffMeritRank()
        {
            return _admissionRepository.GetCollgeCutOffRank();
        }

        public IEnumerable<CutOffMeritMark> GetCutOffMeritMark()
        {
            return _admissionRepository.GetCollgeCutOffMark();
        }

        public IEnumerable<CollegeVacantSeats> GetPercentageOfVacantSeat()
        {
            return _admissionRepository.GetPercentageOfVacantSeat();
        }
    }
}
