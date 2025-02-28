using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;
using Portfolio.Service.Abstract;
using System.Net.Http;
using System.Text;

namespace Portfolio.UI.Controllers
{
    public class ProjectDetailController : Controller
    {
		private readonly IProjectDetailService _projectDetailService;
		private readonly IMapper _mapper;
		private readonly ILogger<ProjectDetailController> _logger;

		public ProjectDetailController(IProjectDetailService projectDetailService, IMapper mapper, ILogger<ProjectDetailController> logger)
		{
			_projectDetailService = projectDetailService;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			var values = _projectDetailService.TGetListAll();

			return View(_mapper.Map<List<ProjectDetailDto>>(values));
		}
		[HttpGet]
		public IActionResult CreateProjectDetail(int id)
		{
			TempData["id"] = id;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProjectDetail(ProjectDetailDto var)
		{
			try
			{
				int pid = int.Parse(TempData["id"].ToString());
				var.ProjectId = pid;
				var.ID = 0;
				var value = _mapper.Map<ProjectDetail>(var);
				_projectDetailService.TAdd(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}


		}
		public async Task<IActionResult> DeleteProjectDetail(int id)
		{
			try
			{
				var value = _projectDetailService.TGetByID(id);
				_projectDetailService.TDelete(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}
		}
		[HttpGet]
		public async Task<IActionResult> UpdateProjectDetail(int id)
		{
			try
			{
				var value = _projectDetailService.TGetByID(id);
				return View(_mapper.Map<ProjectDetailDto>(value));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProjectDetail(ProjectDetailDto var)
		{
			try
			{
				var value = _mapper.Map<ProjectDetail>(var);
				_projectDetailService.TUpdate(value);
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
