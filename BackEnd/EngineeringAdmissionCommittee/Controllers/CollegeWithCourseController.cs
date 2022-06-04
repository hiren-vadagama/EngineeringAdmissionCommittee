using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringAdmissionCommitteeAPI.Controllers
{
    [ApiController]
    [Route("api/collegeWithCourse")]
    public class CollegeWithCourseController : ControllerBase
    {
        private readonly ICollegeWithCourseService _collegeWithCourseService;
        private readonly IMapper _mapper;

        public CollegeWithCourseController(ICollegeWithCourseService collegeWithCourseService, IMapper mapper)
        {
            _collegeWithCourseService = collegeWithCourseService ??
                throw new ArgumentNullException(nameof(collegeWithCourseService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<CollegeWithCourseDto>> GetAllCollegeWithCourses()
        {
            try
            {
                var collegeWithCoursesEntity = _collegeWithCourseService.GetAllCollgeWithCourses();
                return Ok(_mapper.Map<IEnumerable<CollegeWithCourseDto>>(collegeWithCoursesEntity));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("college")]
        public ActionResult<IEnumerable<CollegeDto>> GetAllCollegesDetails()
        {
            try
            {
                var collegeEntity = _collegeWithCourseService.GetAllCollegesDetails();
                return Ok(_mapper.Map<IEnumerable<CollegeDto>>(collegeEntity));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("college/{collegeId}")]
        public ActionResult<IEnumerable<CourseDto>> GetCoursesByCollegeId(Guid collegeId)
        {
            try
            {
                var courseEntity = _collegeWithCourseService.GetCoursesByCollegeId(collegeId);
                return Ok(_mapper.Map<IEnumerable<CourseDto>>(courseEntity));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
