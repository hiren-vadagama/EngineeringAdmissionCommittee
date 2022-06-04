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
    public class AdmissionProfile : Profile
    {
        public AdmissionProfile()
        {
            CreateMap<AdmissionModel, Admission>()
                .ForMember(destination => destination.CollegeName, source => source.MapFrom(admission => admission.CollegeWithCourse.College.CollegeName))
                .ForMember(destination => destination.CourseName, source => source.MapFrom(admission => admission.CollegeWithCourse.Course.CourseName));

            CreateMap<Admission, AdmissionModel>();

            CreateMap<AdmissionModel, StudentAdmission>()
                .ForMember(destination => destination.Rank, source => source.MapFrom(admission => admission.Student.Merit.Rank))
                .ForMember(destination => destination.BoardMark, source => source.MapFrom(admission => admission.Student.BoardMark))
                .ForMember(destination => destination.GujcetMark, source => source.MapFrom(admission => admission.Student.GujcetMark));



        }
    }
}
