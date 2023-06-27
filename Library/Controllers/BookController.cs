using Library.Contracts;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllBooksAsync();

            return View(model);
        }
        public async Task<IActionResult> Mine()
        {
            var model = await bookService.GetMyBooksAsync(GetUserId());
            return View(model);
        }
        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.GetBookByAsync(id);
            if (book == null)
            {
                return RedirectToAction("All");
            }
            var userId = GetUserId();

            await bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction("All");
        }
        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.GetBookByAsync(id);
            if (book == null)
            {
                return RedirectToAction("Mine");
            }
            var userId = GetUserId();

            await bookService.RemoveBookFromCollectionAsync(userId, book);

            return RedirectToAction("Mine");
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await bookService.GetNewAddBookModelAsync();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            decimal rating;

            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0.00 and 10.00!");

                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);

            return RedirectToAction("All");
        }
    }
}
