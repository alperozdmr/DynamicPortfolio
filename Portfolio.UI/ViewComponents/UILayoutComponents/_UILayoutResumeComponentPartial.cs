using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Service.Abstract;
using Portfolio.UI.CustomeModel;

namespace Portfolio.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutResumeComponentPartial : ViewComponent
    {
		private readonly IEducationService _educationService;
		private readonly IExperienceService _experienceService;
		private readonly ILogger<_UILayoutResumeComponentPartial> _logger;

		public _UILayoutResumeComponentPartial(IEducationService educationService, IExperienceService experienceService, ILogger<_UILayoutResumeComponentPartial> logger)
		{
			_educationService = educationService;
			_experienceService = experienceService;
			_logger = logger;
		}


		public async Task<IViewComponentResult> InvokeAsync()
        {
			var educations = _educationService.TGetListAll();
			var experiences = _experienceService.TGetListAll();

			var Resume = new Resume
			{
				Educations = educations,
				Experiences = experiences,
			};
			return View(Resume);
		}
    }
}
