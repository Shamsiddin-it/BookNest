using System.Globalization;
using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class BookService(IBookRepository bookRepository) : IBookService
{
    private IBookRepository repository = bookRepository;

    public ApiResponse<bool> AddBook(Book book)
    {
        var res = repository.AddBook(book);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public ApiResponse<bool> DeleteBook(int id)
    {
        var res = repository.DeleteBook(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public ApiResponse<Book> GetBook(int id)
    {
        var res = repository.GetBook(id);
        return new ApiResponse<Book>(HttpStatusCode.OK, "Book with given id.", res);
    }

    public ApiResponse<List<Book>> GetBooks()
    {
        var res = repository.GetBooks();
        return new ApiResponse<List<Book>>(HttpStatusCode.OK, "List of books.", res);
    }

    public ApiResponse<List<Book>> GetBooksByAuthorId(int authorId)
    {
        var res = repository.GetBooksByAuthorId(authorId);
        return new ApiResponse<List<Book>>(HttpStatusCode.OK, "List of books of given author id.", res);
    }


    public ApiResponse<bool> UpdateBook(Book book)
    {
        var res = repository.UpdateBook(book);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

}
