using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookAsync(AddBookViewModel model);
        Task AddBookToCollectionAsync(string userId, BookViewModel book);
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        Task <BookViewModel?>GetBookByAsync(int id);
        Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId);
        Task<AddBookViewModel> GetNewAddBookModelAsync();
        Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);
    }
}
