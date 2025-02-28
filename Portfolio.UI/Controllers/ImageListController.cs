using Microsoft.AspNetCore.Mvc;
using Portfolio.Entity.concrete;
using Portfolio.Helper.Dtos;
using Portfolio.Service.Abstract;

namespace Portfolio.UI.Controllers
{
	public class ImageListController : Controller
	{
		private readonly IImageListService _imageListService;
		private readonly ILogger<ImageListController> _logger;

		public ImageListController(IImageListService imageListService, ILogger<ImageListController> logger)
		{
			_imageListService = imageListService;
			_logger = logger;
		}

		public IActionResult Index()
		{
			
			return View(_imageListService.TGetListAll());
		}
		public IActionResult CreateImageList(int id) {
			TempData["id"]=id;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateImageList(ImageList var, IFormFile ImageFile)
		{
			var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ımage", ImageFile.FileName);
			await using FileStream stream = new FileStream(path, FileMode.Create);
			await ImageFile.CopyToAsync(stream);
			var.ImageUrl = "/ımage/" + ImageFile.FileName;
			try
			{
				int pid = int.Parse(TempData["id"].ToString());
				var.ProjectId = pid;
				var.ID = 0;
				_imageListService.TAdd(var);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return View();
			}


		}
		public async Task<IActionResult> DeleteImageList(int id)
		{
			try
			{
				var value = _imageListService.TGetByID(id);
				_imageListService.TDelete(value);
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
