using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;

namespace EngineeringAdmissionCommitteeAPI.Profiles
{
    public class CollegeProfile : Profile
    {
        public CollegeProfile()
        {
            CreateMap<College, CollegeDto>().ReverseMap();
        }
    }
}
