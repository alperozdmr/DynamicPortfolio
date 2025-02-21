using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.UI.Dtos;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutResumeComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutResumeComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7059/api/Resume/GetResume");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<Resume>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
