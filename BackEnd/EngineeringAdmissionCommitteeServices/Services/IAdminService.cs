﻿using EngineeringAdmissionCommitteeDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteeServices.Services
{
    public interface IAdminService
    {
        void GenerateMarit(Admin admin);
        void StudentAdmission(Guid studentId);
    }
}