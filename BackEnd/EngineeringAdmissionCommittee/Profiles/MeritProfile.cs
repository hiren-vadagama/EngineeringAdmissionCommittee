using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;

namespace EngineeringAdmissionCommitteeAPI.Profiles
{
    public class MeritProfile : Profile
    {
        public MeritProfile()
        {
            CreateMap<Merit, MeritDto>().ReverseMap();
        }
    }
}
