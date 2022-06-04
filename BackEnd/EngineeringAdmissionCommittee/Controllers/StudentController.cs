using AutoMapper;
using EngineeringAdmissionCommitteeAPI.Models;
using EngineeringAdmissionCommitteeDomain.Entities;
using EngineeringAdmissionCommitteeServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace EngineeringAdmissionCommitteeAPI.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService ??
                throw new ArgumentNullException(nameof(studentService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDetailsDto>> GetAllStudents()
        {
            try
            {
                var studentEntity = _studentService.GetAllStudents();
                return Ok(_mapper.Map<IEnumerable<StudentDetailsDto>>(studentEntity));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("preferences")]
        public ActionResult<IEnumerable<StudentWithPreferenceCollegesDto>> GetStudentsWithPreferences()
        {
            try
            {
                var studentEntity = _studentService.GetAllStudentsWithPreferences();
                return Ok(_mapper.Map<IEnumerable<StudentWithPreferenceCollegesDto>>(studentEntity));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{studentId}")]
        public ActionResult<StudentDetailsDto> GetStudentDetailsByStudentId(Guid studentId)
        {
            try
            {
                var studentEntity = _studentService.GetStudentDetailsByStudentId(studentId);
                return Ok(_mapper.Map<StudentDetailsDto>(studentEntity));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{studentId}/preferences")]
        public ActionResult<StudentWithPreferenceCollegesDto> GetStudentWithPreferenceColleges(Guid studentId)
        {
            try
            {
                var preferenceCollegesEntity = _studentService.GetStudentWithPreferenceColleges(studentId);
                return Ok(_mapper.Map<StudentWithPreferenceCollegesDto>(preferenceCollegesEntity));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<StudentDetailsDto> AddStudent(StudentCreationDto studentCreationDto)
        {
            try
            {
                var studentEntity = _mapper.Map<Student>(studentCreationDto);
                _studentService.AddStudent(studentEntity);

                var studentToReturn = _mapper.Map<StudentDetailsDto>(studentEntity);

                return CreatedAtRoute(
                    new { studentId = studentToReturn.StudentId },
                    studentToReturn
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
