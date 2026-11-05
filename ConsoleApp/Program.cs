using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;

AppDbContext dapperContext = new AppDbContext();

var bookRepo = new BookRepository(dapperContext);
var authorRepo = new AuthorRepository(dapperContext);

while (true)
{
    System.Console.WriteLine("======================================");
    System.Console.WriteLine(@"1. Show all books.
2. Show book by id.
3. Add new book.
4. Update book.
5. Delete book.
6. Show all authors.
7. Show author by id.
8. Add new author.
9. Update author.
10. Delete author.
11. Show all genres.
12. Add new genre.
13. Update genre.
14. Delete genre.
0. Exit.");
    var a = Console.ReadLine();
    System.Console.WriteLine("======================================");
    switch (a)
    {
        case "1":
            var books = bookRepo.GetBooks();
            foreach (var b in books)
            {
                System.Console.WriteLine(b.Id + " " + b.Title + " " + b.PublishedYear + " " + b.TotalCopies);
            }
            break;
        case "2":
            System.Console.Write("Enter id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var bb = bookRepo.GetBook(id);
            System.Console.WriteLine(bb.Id + " " + bb.Title + " " + bb.PublishedYear + " " + bb.TotalCopies);
            break;
        case "3":
            System.Console.Write("Enter title: ");
            var t = Console.ReadLine()!;
            System.Console.Write("Enter published year: ");
            var py = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter total copies: ");
            var tc = Convert.ToInt32(Console.ReadLine());
            var bbb = new Book()
            {
                Title = t,
                PublishedYear = py,
                TotalCopies = tc
            };
            bookRepo.AddBook(bbb);
            break;
        case "4":
            System.Console.Write("Enter id: ");
            var uid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter title: ");
            var ut = Console.ReadLine()!;
            System.Console.Write("Enter published year: ");
            var upy = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter total copies: ");
            var utc = Convert.ToInt32(Console.ReadLine());
            var ubbb = new Book()
            {
                Id = uid,
                Title = ut,
                PublishedYear = upy,
                TotalCopies = utc
            };
            bookRepo.UpdateBook(ubbb);
            break;
        case "5":
            System.Console.Write("Enter id: ");
            var did = Convert.ToInt32(Console.ReadLine());
            bookRepo.DeleteBook(did);
            break;
        case "6":
            var authors = authorRepo.GetAuthors();
            foreach(var z in authors)
            {
                System.Console.WriteLine(z.Id+" "+z.Fullname+" "+z.Country+" "+z.BirthYear);
            }
            break;
        case "0":
            System.Console.WriteLine("Exiting...");
            return;
    }
}