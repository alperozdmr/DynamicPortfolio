using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Service.Abstract;
using Portfolio.Helper.Dtos;
using MimeKit;
using MailKit.Net.Smtp;
using Portfolio.UI.CustomeModel;

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
				//var values = _contactService.TGetListAll();
				var values = _contactService.TWhere(x=>x.Status == false);
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
		[HttpGet]
		public async Task<IActionResult> ResponseMessage(int id) {

			TempData["id"] = id;
			return View();

        }
		
		public async Task<IActionResult> ResponseMessage(ResponseMessage var)
		{
			var id = int.Parse(TempData["id"].ToString());
			var value = _contactService.TGetByID(id);
			_contactService.TChangeStausTrue(id);

			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("Alper Özdemir", "alozdemir23@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress(value.NameSurname, value.Email);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = var.Message;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = value.Subject;

			SmtpClient clientM = new SmtpClient();
			clientM.Connect("smtp.gmail.com", 587, false);
			clientM.Authenticate("alozdemir23@gmail.com", "yyfy vmjh rsla hwgl");

			clientM.Send(mimeMessage);
			clientM.Disconnect(true);
			return RedirectToAction("Index");
		}
	}
}
