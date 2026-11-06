using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepository(AppDbContext context) : IAuthorRepository
{
    private AppDbContext _context = context;

    public async Task<bool> AddAuthor(Author author)
    {
        var connection = _context.Connection();
        var query = "insert into authors(fullname, country, birthyear) values(@fullname, @country, @birthyear)";
        var res = await connection.ExecuteAsync(query, author);
        return res>0;
    }

    public async Task<bool> DeleteAuthor(int id)
    {
        var connection = _context.Connection();
        var query = "delete from authors where id=@id";
        var res = await connection.ExecuteAsync(query, new{id});
        return res>0;
    }

    public async Task<Author> GetAuthor(int id)
    {
        var connection = _context.Connection();
        var query = "select * from authors where id=@id";
        var res = await connection.QuerySingleOrDefaultAsync<Author>(query, new{id});
        return res!;
    }

    public async Task<List<Author>> GetAuthors()
    {
        var connection = _context.Connection();
        var query = "select * from authors";
        var res = await connection.QueryAsync<Author>(query);
        return res.ToList();    
    }

    public async Task<bool> UpdateAuthor(Author author)
    {
        var connection = _context.Connection();
        var query = "update authors set fullname=@fullname, country=@country, birthyear=@birthyear where id=@id";
        var res = await connection.ExecuteAsync(query, author);
        return res>0;
    }
}
