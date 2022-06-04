using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;

namespace EngineeringAdmissionCommitteeAPI.Profiles
{
    public class CollegeWithCourseProfile : Profile
    {
        public CollegeWithCourseProfile()
        {
            CreateMap<CollegeWithCourse, CollegeWithCourseDto>().ReverseMap();
        }
    }
}
