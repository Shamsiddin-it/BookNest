using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IBookService
{
    ApiResponse<bool> AddBook(Book book);
    ApiResponse<bool> UpdateBook(Book book);
    ApiResponse<bool> DeleteBook(int id);
    ApiResponse<Book> GetBook(int id);
    ApiResponse<List<Book>> GetBooks();

    ApiResponse<List<Book>> GetBooksByAuthorId(int authorId);
}
