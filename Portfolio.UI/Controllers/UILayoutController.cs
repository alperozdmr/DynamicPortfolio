using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using Portfolio.UI.Dtos;
using System.Text;

namespace Portfolio.UI.Controllers
{
    public class UILayoutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UILayoutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Message(ContactDto var) {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(var);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7059/api/Contact", content);
            if (responseMessage.IsSuccessStatusCode)
            {
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
            return View();
        }
    }
}
