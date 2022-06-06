using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringAdmissionCommitteeAPI.Controllers
{
    [ApiController]
    [Route("api/report")]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService ??
                throw new ArgumentNullException(nameof(reportService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("cut-off-rank")]
        public ActionResult<IEnumerable<CutOffMeritRankDto>> GetCutOffMeritRank()
        {
            try
            {
                var cutOffMeritRankEntity = _reportService.GetCutOffMeritRank();
                return Ok(_mapper.Map<IEnumerable<CutOffMeritRankDto>>(cutOffMeritRankEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("cut-off-mark")]
        public ActionResult<IEnumerable<CutOffMeritMarkDto>> GetCutOffMeritMark()
        {
            try
            {
                var cutOffMeritMarkEntity = _reportService.GetCutOffMeritMark();
                return Ok(_mapper.Map<IEnumerable<CutOffMeritMarkDto>>(cutOffMeritMarkEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("vacant-seat")]
        public ActionResult<IEnumerable<CollegeVacantSeatsDto>> GetPercentageOfVacantSeat()
        {
            try
            {
                var perOfVacantSeatEntity = _reportService.GetPercentageOfVacantSeat();
                return Ok(_mapper.Map<IEnumerable<CollegeVacantSeatsDto>>(perOfVacantSeatEntity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
