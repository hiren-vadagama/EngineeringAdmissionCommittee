using AutoMapper;
using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteePersistance.Datamodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringAdmissionCommitteePersistance.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentModel, Student>().ReverseMap();
        }
    }
}
