using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Abstract;
using Portfolio.UI.CustomeModel;

namespace Portfolio.UI.Controllers
{
    [AllowAnonymous]
    public class UIProjectReviewController : Controller
	{
		private readonly IProjectDetailService _projectDetailService;
		private readonly IImageListService _imageListService;

		public UIProjectReviewController(IProjectDetailService projectDetailService, IImageListService imageListService)
		{
			_projectDetailService = projectDetailService;
			_imageListService = imageListService;
		}

		public IActionResult Index(int id)
		{
			var project = _projectDetailService.TWhere(x=>x.ProjectId == id).FirstOrDefault();
			var ımages = _imageListService.TWhere(y => y.ProjectId == id);
			var projectReview = new UIProjectReview()
			{
				Category = project.Category,
				Client = project.Client,
				ProjectUrl = project.ProjectUrl,
				Header = project.Header,
				Description = project.Description,
				ImageLists = ımages,
			};
			return View(projectReview);
		}
	}
}
