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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProjectList()
        {
            var values = _projectService.TGetListAll();
            return Ok(_mapper.Map<List<ProjectDto>>(values));
        }
        [HttpPost]
        public IActionResult AddProject(ProjectDto var)
        {
            var value = _mapper.Map<Project>(var);
            _projectService.TAdd(value);
            return Ok("Proje kısmı başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var value = _projectService.TGetByID(id);
            _projectService.TDelete(value);
            return Ok("Proje alanı silindi");
        }
        [HttpPut]
        public IActionResult UpdateProject(ProjectDto var)
        {
            var value = _mapper.Map<Project>(var);
            _projectService.TUpdate(value);
            return Ok("Proje alanı güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            var value = _projectService.TGetByID(id);
            return Ok(_mapper.Map<ProjectDto>(value));
        }
    }
}
