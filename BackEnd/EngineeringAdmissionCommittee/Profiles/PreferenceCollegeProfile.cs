using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;

namespace EngineeringAdmissionCommitteeAPI.Profiles
{
    public class PreferenceCollegeProfile : Profile
    {
        public PreferenceCollegeProfile()
        {
            CreateMap<PreferenceCollegeDto, PreferenceCollege>().ReverseMap();
            CreateMap<PreferenceCollegeCreationDto, PreferenceCollege>().ReverseMap();
        }
    }
}
