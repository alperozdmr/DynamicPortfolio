using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.UI.Dtos;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutAboutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7059/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
