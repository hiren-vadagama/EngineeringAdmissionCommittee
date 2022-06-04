using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringAdmissionCommitteeAPI.Controllers
{
    [ApiController]
    [Route("api/admission")]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionService _admissionService;
        private readonly IMapper _mapper;

        public AdmissionController(IAdmissionService admissionService, IMapper mapper)
        {
            _admissionService = admissionService ?? throw new ArgumentNullException((nameof(admissionService)));
            _mapper = mapper ?? throw new ArgumentNullException((nameof(mapper)));
        }

        [HttpPost("student/{studentId}")]
        public ActionResult AdmissionByPreference(Guid studentId)
        {
            try
            {
                _admissionService.AdmissionByPreference(studentId);
                return Ok("Student admit successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("student/{studentId}/collegeWithCourse/{collegeWithCourseId}")]
        public ActionResult AdmissionByChoice(Guid studentId, Guid collegeWithCourseId)
        {
            try
            {
                _admissionService.AdmissionByCollegeWithCourseId(studentId, collegeWithCourseId);
                return Ok("Student admit successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
