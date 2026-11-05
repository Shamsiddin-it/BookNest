using Domain.Models;

namespace Domain.Interfaces;

public interface IBookRepository
{
    bool AddBook(Book book);
    bool UpdateBook(Book book);
    bool DeleteBook(int id);
    Book GetBook(int id);
    List<Book> GetBooks();
}
