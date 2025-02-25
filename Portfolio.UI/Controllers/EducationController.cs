using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Service.Abstract;
using Portfolio.Helper.Dtos;
using System.Text;
using Portfolio.Entity.concrete;

namespace Portfolio.UI.Controllers
{
	public class EducationController : Controller
	{
		private readonly IEducationService _educationService;
		private readonly IMapper _mapper;
		private readonly ILogger<EducationController> _logger;

		public EducationController(IEducationService EducationService, IMapper mapper, ILogger<EducationController> logger)
		{
			_educationService = EducationService;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{

			var values = _educationService.TGetListAll();
			return View(_mapper.Map<List<EducationDto>>(values));
		}
		[HttpGet]
		public IActionResult CreateEducation()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateEducation(EducationDto var)
		{
			try
			{
				var value = _mapper.Map<Education>(var);
				_educationService.TAdd(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}

		}
		public async Task<IActionResult> DeleteEducation(int id)
		{
			try
			{
				var value = _educationService.TGetByID(id);
				_educationService.TDelete(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}
		}
		[HttpGet]
		public async Task<IActionResult> UpdateEducation(int id)
		{
			try
			{
				var value = _educationService.TGetByID(id);
				return View(_mapper.Map<EducationDto>(value));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}
		}
		[HttpPost]
		public async Task<IActionResult> UpdateEducation(EducationDto var)
		{
			try
			{
				var value = _mapper.Map<Education>(var);
				_educationService.TUpdate(value);
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
