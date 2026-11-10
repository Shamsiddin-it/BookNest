using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AuthorService(
    IAuthorRepository authorRepository,
    IBookRepository bookRepository
    ) : IAuthorService
{
    private IAuthorRepository repository = authorRepository;
    private readonly IBookRepository _bookRepository = bookRepository;
    public async Task<ApiResponse<bool>> AddAuthor(Author author)
    {
        var res = await repository.AddAuthor(author);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        var res = await repository.DeleteAuthor(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<Author>> GetAuthor(int id)
    {
        var res = await repository.GetAuthor(id);
        return res!=null
        ? new ApiResponse<Author>(HttpStatusCode.OK, "Author with given id.", res)
        : new ApiResponse<Author>(HttpStatusCode.NotFound, "No author with given id.", res!);
    }

    public async Task<ApiResponse<List<Author>>> GetAuthors()
    {
        var res = await repository.GetAuthors();
        return new ApiResponse<List<Author>>(HttpStatusCode.OK, "List of authors.", res);
    }

    public async Task<ApiResponse<List<AuthorWithBooks>>> GetAuthorsWithBooks()
    {
        var authors = await repository.GetAuthors();
        var res = authors.Select(x=>new AuthorWithBooks()
        {
            Id = x.Id,
            Fullname = x.Fullname,
            Country = x.Country,
            BirthYear = x.BirthYear,
            Books = _bookRepository.GetBooksByAuthorId(x.Id)
        }).ToList();
        return new ApiResponse<List<AuthorWithBooks>>(HttpStatusCode.OK, "List of authors.", res);
    }


    public async Task<ApiResponse<bool>> UpdateAuthor(Author author)
    {
        var res = await repository.UpdateAuthor(author);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

}
