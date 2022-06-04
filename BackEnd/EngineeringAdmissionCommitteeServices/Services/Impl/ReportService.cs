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

        public void GetCutOffRank()
        {
            var studentAdmission = _admissionRepository.GetStudentsAdmissionDetails();
            var group = studentAdmission.GroupBy(student => student.CollegeWithCourseId)
                                        .Select(student => new CutOffMeritRank {
                                                                 CollegeWithCourseId = student.Key,
                                                                 Rank = student.Max(x=>x.Rank)});
        }
    }
}
