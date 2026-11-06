using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthorRepository
{
    Task<bool> AddAuthor(Author author);
    Task<bool> UpdateAuthor(Author author);
    Task<bool> DeleteAuthor(int id);
    Task<Author> GetAuthor(int id);
    Task<List<Author>> GetAuthors();
}
