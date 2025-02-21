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
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        private readonly IMapper _mapper;

        public EducationController(IEducationService EducationService, IMapper mapper)
        {
            _educationService = EducationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult EducationList()
        {
            var values = _educationService.TGetListAll();
            return Ok(_mapper.Map<List<EducationDto>>(values));
        }
        [HttpPost]
        public IActionResult AddEducation(EducationDto var)
        {
            var value = _mapper.Map<Education>(var);
            _educationService.TAdd(value);
            return Ok("Eğitim kısmı başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEducation(int id)
        {
            var value = _educationService.TGetByID(id);
            _educationService.TDelete(value);
            return Ok("Eğitim alanı silindi");
        }
        [HttpPut]
        public IActionResult UpdateEducation(EducationDto var)
        {
            var value = _mapper.Map<Education>(var);
            _educationService.TUpdate(value);
            return Ok("Eğitim alanı güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetEducation(int id)
        {
            var value = _educationService.TGetByID(id);
            return Ok(_mapper.Map<EducationDto>(value));
        }
    }
}
