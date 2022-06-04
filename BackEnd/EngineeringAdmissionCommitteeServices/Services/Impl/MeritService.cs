using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services.Impl
{
    public class MeritService : IMeritService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMeritRepository _meritRepository;

        public MeritService(IAdminRepository adminRepository,
                            IMeritRepository meritRepository)
        {
            _adminRepository = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
            _meritRepository = meritRepository ?? throw new ArgumentNullException(nameof(meritRepository));
        }

        public void GenerateMarit(Admin admin)
        {
            if (!AdminExists(admin.AdminId))
            {
                throw new ArgumentException("Invalidate admin");
            }

            _meritRepository.GenerateMerit();
        }

        public bool AdminExists(Guid adminId)
        {
            if (adminId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(adminId));
            }

            return _adminRepository.AdminExists(adminId);
        }

        public IEnumerable<Merit> GetMerits()
        {
            return _meritRepository.GetMerits();
        }
    }
}
