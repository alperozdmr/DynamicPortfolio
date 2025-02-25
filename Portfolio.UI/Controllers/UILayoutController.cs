using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using Portfolio.Entity.concrete;
using Portfolio.Service.Abstract;
using Portfolio.Helper.Dtos;
using System.Text;

namespace Portfolio.UI.Controllers
{
    public class UILayoutController : Controller
    {
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;
		private readonly ILogger<UILayoutController> _logger;

		public UILayoutController(IContactService ContactService, IMapper mapper, ILogger<UILayoutController> logger)
		{
			_contactService = ContactService;
			_mapper = mapper;
			_logger = logger;
		}
		public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Message(ContactDto var) {
            try
            {
                var value = _mapper.Map<Contact>(var);
                _contactService.TAdd(value);

                MimeMessage mimeMessage = new MimeMessage();

                MailboxAddress mailboxAddressFrom = new MailboxAddress("Alper Özdemir", "alozdemir23@gmail.com");
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailboxAddressTo = new MailboxAddress(var.NameSurname, var.Email);
                mimeMessage.To.Add(mailboxAddressTo);

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Merhaba " + var.NameSurname + " fikriniz için teşekür ederim";
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                mimeMessage.Subject = var.Subject;

                SmtpClient clientM = new SmtpClient();
                clientM.Connect("smtp.gmail.com", 587, false);
                clientM.Authenticate("alozdemir23@gmail.com", "yyfy vmjh rsla hwgl");

                clientM.Send(mimeMessage);
                clientM.Disconnect(true);
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
