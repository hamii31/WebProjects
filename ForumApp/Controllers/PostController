using Forum.Services.Interfaces;
using Forum.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
	public class PostController : Controller
	{
		private readonly IPostService postService;
		public PostController(IPostService postService)
		{
			this.postService = postService;
		}
		public async Task<IActionResult> All()
		{
			IEnumerable<PostListViewModel> allPosts = await this.postService.ListAllAsync();
			return View(allPosts);
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(PostAddFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			try
			{
				await this.postService.AddVoidAsync(model);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while adding your post!");

				return View(model);
			}
			return RedirectToAction("All");
		}
		public async Task<IActionResult> Edit(string id) 
		{
			try
			{
				PostAddFormModel postModel = await this.postService.GetIdForEditOrDelete(id);
				return View(postModel);
			}
			catch (Exception)
			{
				return this.RedirectToAction("All");
				// or make a custom 404 page and redirect it there
			}
		}
		[HttpPost]
		public async Task<IActionResult> Edit(string id, PostAddFormModel postModel)
		{
			if (!ModelState.IsValid)
			{
				return View(postModel);
			}

			try
			{
				await this.postService.EditByIdASync(id, postModel);
			}
			catch (Exception)
			{
				ModelState.AddModelError(string.Empty, "Unexpected error occurred while updating your post!");

				return View(postModel);
			}
			return RedirectToAction("All");
		}
		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			try
			{
				await this.postService.DeleteByIdASync(id);
			}
			catch (Exception)
			{
				//nothing to do here, the client manually checks if the file is deleted successfully
			}
			return RedirectToAction("All");
		}
	}
}
