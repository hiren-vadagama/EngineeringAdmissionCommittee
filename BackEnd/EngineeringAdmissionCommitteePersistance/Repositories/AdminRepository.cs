using AutoMapper;
using EngineeringAdmissionCommitteeDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteePersistance.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EngineeringAdmissionCommitteeContext _context;
        private readonly IMapper _mapper;

        public AdminRepository(EngineeringAdmissionCommitteeContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public bool AdminExists(Guid adminId)
        {
            return _context.Admins.Any(admin => admin.AdminId == adminId);
        }
    }
}
