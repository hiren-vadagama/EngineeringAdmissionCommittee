using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringAdmissionCommitteeAPI.Controllers
{
    [ApiController]
    [Route("api/merit")]
    public class MeritController : ControllerBase
    {
        private readonly IMeritService _meritService;
        private readonly IMapper _mapper;

        public MeritController(IMeritService meritService, IMapper mapper)
        {
            _meritService = meritService ?? throw new ArgumentNullException((nameof(meritService)));
            _mapper = mapper ?? throw new ArgumentNullException((nameof(mapper)));
        }

        [HttpPost("generate")]
        public ActionResult GenerateMerit(AdminDto adminDto)
        {
            try
            {
                var maritEntity = _mapper.Map<Admin>(adminDto);
                _meritService.GenerateMarit(maritEntity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<MeritDto>> GetMerits()
        {
            try
            {
                var meritEntity = _meritService.GetMerits();
                return Ok(_mapper.Map<IEnumerable<MeritDto>>(meritEntity));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}