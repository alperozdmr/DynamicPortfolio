using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;
using Portfolio.Service.Abstract;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        private readonly IMapper _mapper;

        public ExperienceController(IExperienceService ExperienceService, IMapper mapper)
        {
            _experienceService = ExperienceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ExperienceList()
        {
            var values = _experienceService.TGetListAll();
            return Ok(_mapper.Map<List<ExperienceDto>>(values));
        }
        [HttpPost]
        public IActionResult AddExperience(ExperienceDto var)
        {
            var value = _mapper.Map<Experience>(var);
            _experienceService.TAdd(value);
            return Ok("Tecrübe kısmı başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteExperience(int id)
        {
            var value = _experienceService.TGetByID(id);
            _experienceService.TDelete(value);
            return Ok("Tecrübe alanı silindi");
        }
        [HttpPut]
        public IActionResult UpdateExperience(ExperienceDto var)
        {
            var value = _mapper.Map<Experience>(var);
            _experienceService.TUpdate(value);
            return Ok("Tecrübe alanı güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetExperience(int id)
        {
            var value = _experienceService.TGetByID(id);
            return Ok(_mapper.Map<ExperienceDto>(value));
        }
    }
}
