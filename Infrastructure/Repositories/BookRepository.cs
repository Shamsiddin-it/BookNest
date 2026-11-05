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
        var query = "insert into books(title, publishedyear, totalcopies) values(@title, @publishedyear, @totalcopies)";
        var res = connection.Execute(query, new{book.Title, book.PublishedYear, book.TotalCopies});
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

    public bool UpdateBook(Book book)
    {
        using var connection = context.Connection();
        connection.Open();
        var query = "update books set title=@title, publishedyear=@publishedyear, totalcopies=@totalcopies where id=@id";
        var res = connection.Execute(query, book);
        return res>0;
    }
}