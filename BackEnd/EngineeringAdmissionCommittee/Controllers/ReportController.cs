using AutoMapper;
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

        [HttpGet]
        public ActionResult GetCutOffRank()
        {
            try
            {
                _reportService.GetCutOffRank();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
