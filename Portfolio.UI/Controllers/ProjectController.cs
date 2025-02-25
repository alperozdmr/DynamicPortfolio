using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Service.Abstract;
using Portfolio.Helper.Dtos;
using System.Text;
using Portfolio.Entity.concrete;

namespace Portfolio.UI.Controllers
{
	public class ProjectController : Controller
	{
		private readonly IProjectService _projectService;
		private readonly IMapper _mapper;
		private readonly ILogger<ProjectController> _logger;

		public ProjectController(IProjectService projectService, IMapper mapper, ILogger<ProjectController> logger)
		{
			_projectService = projectService;
			_mapper = mapper;
			_logger = logger;
		}
		public async Task<IActionResult> Index()
		{
			var values = _projectService.TGetListAll();
			return View(_mapper.Map<List<ProjectDto>>(values));
		}
		[HttpGet]
		public IActionResult CreateProject()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProject(ProjectDto var)
		{
			try
			{
				var value = _mapper.Map<Project>(var);
				_projectService.TAdd(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}

		}
		public async Task<IActionResult> DeleteProject(int id)
		{
			try
			{
				var value = _projectService.TGetByID(id);
				_projectService.TDelete(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}
		}
		[HttpGet]
		public async Task<IActionResult> UpdateProject(int id)
		{
			try
			{
				var value = _projectService.TGetByID(id);
				return View(_mapper.Map<ProjectDto>(value));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProject(ProjectDto var)
		{
			try
			{
				var value = _mapper.Map<Project>(var);
				_projectService.TUpdate(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}

		}
	}
}
