using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Portfolio.Helper.Dtos;
using Portfolio.Service.Abstract;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutPortfolioComponentPartial : ViewComponent
    {
		private readonly IProjectService _projectService;
		private readonly IMapper _mapper;
		private readonly ILogger<_UILayoutPortfolioComponentPartial> _logger;

		public _UILayoutPortfolioComponentPartial(IProjectService projectService, IMapper mapper, ILogger<_UILayoutPortfolioComponentPartial> logger)
		{
			_projectService = projectService;
			_mapper = mapper;
			_logger = logger;
		}
		public async Task<IViewComponentResult> InvokeAsync()
        {
			try
			{
				var values = _projectService.TGetListAll();
				return View(_mapper.Map<List<ProjectDto>>(values));
			}
			catch (Exception ex) {
				return View(ex.Message);
			}
		}
    }
}
