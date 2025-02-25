using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Service.Abstract;
using Portfolio.Helper.Dtos;
using System.Text;
using Portfolio.Entity.concrete;

namespace Portfolio.UI.Controllers
{
	public class ExperienceController : Controller
	{
		private readonly IExperienceService _experienceService;
		private readonly IMapper _mapper;
		private readonly ILogger<EducationController> _logger;

		public ExperienceController(IExperienceService ExperienceService, IMapper mapper, ILogger<EducationController> logger)
		{
			_experienceService = ExperienceService;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			var values = _experienceService.TGetListAll();
			return View(_mapper.Map<List<ExperienceDto>>(values));
		}
		[HttpGet]
		public IActionResult CreateExperience()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateExperience(ExperienceDto var)
		{
			try
			{
				var value = _mapper.Map<Experience>(var);
				_experienceService.TAdd(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}

		}
		public async Task<IActionResult> DeleteExperience(int id)
		{
			try
			{
				var value = _experienceService.TGetByID(id);
				_experienceService.TDelete(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}
		}
		[HttpGet]
		public async Task<IActionResult> UpdateExperience(int id)
		{
			try
			{
				var value = _experienceService.TGetByID(id);
				return View(_mapper.Map<ExperienceDto>(value));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			};
		}
		[HttpPost]
		public async Task<IActionResult> UpdateExperience(ExperienceDto var)
		{

			try
			{
				var value = _mapper.Map<Experience>(var);
				_experienceService.TUpdate(value);
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
