using Application.DTOs;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IAuthorService
{
    Task<ApiResponse<bool>> AddAuthor(Author author);
    Task<ApiResponse<bool>> UpdateAuthor(Author author);
    Task<ApiResponse<bool>> DeleteAuthor(int id);
    Task<ApiResponse<Author>> GetAuthor(int id);
    Task<ApiResponse<List<Author>>> GetAuthors();

    Task<ApiResponse<List<AuthorWithBooks>>> GetAuthorsWithBooks();
}
