using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(
    IBookService bookService,
    ILogger<BooksController> logger) : ControllerBase
{
    private IBookService service = bookService;
    private ILogger<BooksController> _logger = logger;

    [HttpGet]
    public ApiResponse<List<Book>> GetBooks()
    {
        _logger.LogInformation("GET api/Books {date}", DateTime.Now);
        return service.GetBooks();
    }

    [HttpGet("{id:int}")]
    public ApiResponse<Book> GetBook(int id)
    {
        return service.GetBook(id);
    }

    [HttpPost]
    public ApiResponse<bool> AddBook(Book book)
    {
        return service.AddBook(book);
    }

    [HttpDelete]
    public ApiResponse<bool> DeleteBook(int id)
    {
        return service.DeleteBook(id);
    }

    [HttpPut]
    public ApiResponse<bool> UpdateBook(Book book)
    {
        return service.UpdateBook(book);
    }

    [HttpGet("get-by-authorId{authorId:int}")]
    public ApiResponse<List<Book>> GetBooksByAuthorId(int authorId)
    {
        return service.GetBooksByAuthorId(authorId);
    }
}
