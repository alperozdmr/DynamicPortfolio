using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Entity.concrete;
using Portfolio.Service.Abstract;
using Portfolio.Helper.Dtos;
using System.Text;

namespace Portfolio.UI.Controllers
{
    public class AboutController : Controller
    {
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;
        private readonly ILogger<AboutController> _logger;

		public AboutController(IAboutService aboutService, IMapper mapper, ILogger<AboutController> logger)
		{
			_aboutService = aboutService;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
        {
			var values = _aboutService.TGetListAll();
            return View(_mapper.Map<List<AboutDto>>(values));
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(AboutDto var)
        {
            try {
				var value = _mapper.Map<About>(var);
				_aboutService.TAdd(value);
                return RedirectToAction("Index");
			}
            catch(Exception ex) {
                _logger.LogError(ex.Message);
                return View();
            }

        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
			try
			{
				var value = _aboutService.TGetByID(id);
				_aboutService.TDelete(value);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}

		}
		[HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
			try
			{
				var value = _aboutService.TGetByID(id);
				return View(_mapper.Map<AboutDto>(value));
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}
		}
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutDto var)
        {
			try
			{
				var value = _mapper.Map<About>(var);
				_aboutService.TUpdate(value);
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
