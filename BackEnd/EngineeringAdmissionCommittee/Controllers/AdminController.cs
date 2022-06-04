using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringAdmissionCommitteeAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService ?? throw new ArgumentNullException((nameof(adminService)));
            _mapper = mapper ?? throw new ArgumentNullException((nameof(mapper)));
        }

        [HttpPost("marit")]
        public ActionResult GenerateMarit(AdminDto adminDto)
        {
            try
            {
                var maritEntity = _mapper.Map<Admin>(adminDto);
                _adminService.GenerateMarit(maritEntity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("admission/{studentId}")]
        public ActionResult AdmissionProcess(AdminDto adminDto, Guid studentId)
        {
            try
            {
                var adminEntity = _mapper.Map<Admin>(adminDto);
                _adminService.StudentAdmission(studentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
