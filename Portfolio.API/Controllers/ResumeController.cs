using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.CustomeModel;
using Portfolio.Service.Abstract;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IEducationService _educationService;
        private readonly IExperienceService _experienceService;

        public ResumeController(IEducationService educationService, IExperienceService experienceService)
        {
            _educationService = educationService;
            _experienceService = experienceService;
        }

        [HttpGet("GetResume")]
        public IActionResult GetResume() { 
            
            var educations = _educationService.TGetListAll();
            var experiences = _experienceService.TGetListAll();

            var Resume = new Resume
            {
                Educations = educations,
                Experiences = experiences,  
            };
            return Ok(Resume);
        }
    }
}
