using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;

namespace EngineeringAdmissionCommitteeAPI.Profiles
{
    public class AdmissionProfile : Profile
    {
        public AdmissionProfile()
        {
            CreateMap<Admission, AdmissionDto>().ReverseMap();
        }
    }
}
