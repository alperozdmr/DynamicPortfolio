using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Portfolio.Service.Abstract;
using Portfolio.Helper.Dtos;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutAboutComponentPartial : ViewComponent
    {
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;
		private readonly ILogger<_UILayoutAboutComponentPartial> _logger;

		public _UILayoutAboutComponentPartial(IAboutService aboutService, IMapper mapper, ILogger<_UILayoutAboutComponentPartial> logger)
		{
			_aboutService = aboutService;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {

			var values = _aboutService.TGetListAll();
			return View(_mapper.Map<List<AboutDto>>(values));
		}
    }
}
