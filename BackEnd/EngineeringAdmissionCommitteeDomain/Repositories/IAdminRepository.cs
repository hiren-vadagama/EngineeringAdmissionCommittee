using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeDomain.Repositories
{
    public interface IAdminRepository
    {
        bool AdminExists(Guid adminId);
    }
}
