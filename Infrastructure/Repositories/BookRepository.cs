using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Dapper;

namespace Infrastructure.Repositories;

public class BookRepository(AppDbContext appDbContext) : IBookRepository
{
    private AppDbContext context = appDbContext;
    public bool AddBook(Book book)
    {
        using var connection = context.Connection();
        connection.Open();
        var query = "insert into books(title, publishedyear, totalcopies, authorid) values(@title, @publishedyear, @totalcopies, @authorid)";
        var res = connection.Execute(query, new{book.Title, book.PublishedYear, book.TotalCopies, book.AuthorId});
        return res>0;
    }

    public bool DeleteBook(int id)
    {
        using var connection = context.Connection();
        connection.Open();
        var query = "delete from books where id=@id";
        var res = connection.Execute(query, new{id});
        return res>0;
    }

    public Book GetBook(int id)
    {
        using var connection = context.Connection();
        connection.Open();
        var query = "select * from books where id=@id";
        var book = connection.QuerySingle<Book>(query, new{id});
        return book;
    }


    public List<Book> GetBooks()
    {
        using var connection = context.Connection();
        connection.Open();
        var books = connection.Query<Book>("select * from books");
        return books.ToList();
    }

    public List<Book> GetBooksByAuthorId(int authorid)
    {
        using var connection = context.Connection();
        connection.Open();
        var books = connection.Query<Book>("select * from books where authorid=@authorid", new {authorid});
        return books.ToList();
    }


    public bool UpdateBook(Book book)
    {
        using var connection = context.Connection();
        connection.Open();
        var query = "update books set title=@title, publishedyear=@publishedyear, totalcopies=@totalcopies, authorid=@authorid where id=@id";
        var res = connection.Execute(query, book);
        return res>0;
    }
}