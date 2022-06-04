using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;

namespace EngineeringAdmissionCommitteeAPI.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentDetailsDto, Student>().ReverseMap();
            CreateMap<StudentCreationDto, Student>().ReverseMap();
            CreateMap<StudentWithPreferenceCollegesDto, Student>().ReverseMap();
        }
    }
}
