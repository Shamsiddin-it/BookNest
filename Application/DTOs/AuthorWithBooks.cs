using Domain.Models;

namespace Application.DTOs;

public class AuthorWithBooks
{
    public int Id {get; set;}
    public string Fullname {get; set;}=null!;
    public string Country {get; set;}=null!;
    public int BirthYear {get; set;}

    public List<Book> Books {get; set;}=[];
}
