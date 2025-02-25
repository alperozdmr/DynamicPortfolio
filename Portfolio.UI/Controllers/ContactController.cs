using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Service.Abstract;
using Portfolio.Helper.Dtos;

namespace Portfolio.UI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;
		private readonly ILogger<ContactController> _logger;

		public ContactController(IContactService ContactService, IMapper mapper, ILogger<ContactController> logger)
		{
			_contactService = ContactService;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			try
			{
				var values = _contactService.TGetListAll();
				return View(_mapper.Map<List<ContactDto>>(values));
			}
			catch (Exception ex) { 
				_logger.LogError(ex.Message);
				return View();
			}
		}
		public async Task<IActionResult> DeleteContact(int id)
		{
			try
			{
				var value = _contactService.TGetByID(id);
				_contactService.TDelete(value);
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
