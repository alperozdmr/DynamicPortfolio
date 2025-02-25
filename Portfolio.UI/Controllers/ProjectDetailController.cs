using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Service.Abstract;
using System.Net.Http;
using System.Text;

namespace Portfolio.UI.Controllers
{
    public class ProjectDetailController : Controller
    {
		private readonly IProjectDetailService _projectDetailService;

		public ProjectDetailController(IProjectDetailService projectDetailService)
		{
			_projectDetailService = projectDetailService;
		}

		//public async Task<IActionResult> Index()
		//{
			
		//}
		//[HttpGet]
		//public IActionResult CreateProject()
		//{
		//	return View();
		//}
		//[HttpPost]
		//public async Task<IActionResult> CreateProject(ProjectDto var)
		//{
			

		//}
		//public async Task<IActionResult> DeleteProject(int id)
		//{
			
		//}
		//[HttpGet]
		//public async Task<IActionResult> UpdateProject(int id)
		//{
			
		//}
		//[HttpPost]
		//public async Task<IActionResult> UpdateProject(ProjectDto var)
		//{
			
		//}
	}
}
