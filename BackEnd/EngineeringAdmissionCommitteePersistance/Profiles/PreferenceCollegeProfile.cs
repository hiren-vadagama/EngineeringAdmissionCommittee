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
    public class PreferenceCollegeProfile : Profile
    {
        public PreferenceCollegeProfile()
        {
            CreateMap<PreferenceCollegeModel, PreferenceCollege>()
                .ForMember(destination => destination.CollegeName, source => source.MapFrom(preference => preference.CollegeWithCourse.College.CollegeName))
                .ForMember(destination => destination.CourseName, source => source.MapFrom(preference => preference.CollegeWithCourse.Course.CourseName))
                .ForMember(destination => destination.AvailableSeat, source => source.MapFrom(preference => preference.CollegeWithCourse.AvailableSeat));
            CreateMap<PreferenceCollege, PreferenceCollegeModel>();
        }
    }
}
