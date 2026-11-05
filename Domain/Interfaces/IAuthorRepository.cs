using Domain.Models;

namespace Domain.Interfaces;

public interface IAuthorRepository
{
    void AddAuthor(Author author);
    List<Author> GetAuthors();
}
