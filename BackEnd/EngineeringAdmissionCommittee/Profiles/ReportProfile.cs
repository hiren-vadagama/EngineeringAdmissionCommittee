using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;

namespace EngineeringAdmissionCommitteeAPI.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<CutOffMeritRank, CutOffMeritRankDto>().ReverseMap();
            CreateMap<CutOffMeritMark, CutOffMeritMarkDto>().ReverseMap();
            CreateMap<CollegeVacantSeats, CollegeVacantSeatsDto>().ReverseMap();
        }
    }
}
