using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepository(AppDbContext context) : IAuthorRepository
{
    private AppDbContext _context = context;
    public void AddAuthor(Author author)
    {
        throw new NotImplementedException();
    }

    public List<Author> GetAuthors()
    {
        using var connection = _context.Connection();
        connection.Open();
        var query = "select * from authors";
        var authors = connection.Query<Author>(query);
        return authors.ToList();
    }

}
