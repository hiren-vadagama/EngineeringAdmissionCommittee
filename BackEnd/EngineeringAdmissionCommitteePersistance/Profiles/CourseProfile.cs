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
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
           CreateMap<CourseModel, Course>();
        }
    }
}
