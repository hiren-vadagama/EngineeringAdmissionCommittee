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
    public class CollegeWithCourseProfile : Profile
    {
        public CollegeWithCourseProfile()
        {
            CreateMap<CollegeWithCourseModel, CollegeWithCourse>()
                .ForMember(destination => destination.CollegeName, source => source.MapFrom(collegeWithCourse => collegeWithCourse.College.CollegeName))
                .ForMember(destination => destination.CourseName, source => source.MapFrom(collegeWithCourse => collegeWithCourse.Course.CourseName));
            CreateMap<CollegeWithCourse, CollegeWithCourseModel>();
        }
    }
}
