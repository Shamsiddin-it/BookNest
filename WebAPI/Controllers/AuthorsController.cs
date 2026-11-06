using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(IAuthorService authorService): ControllerBase
{
    private IAuthorService service = authorService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(Author author)
    {
        return await service.AddAuthor(author);
    }
    
    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAuthor(Author author)
    {
        return await service.UpdateAuthor(author);
    }
    
    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        return await service.DeleteAuthor(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Author>> GetAuthor(int id)
    {
        return await service.GetAuthor(id);
    }
    
    [HttpGet]
    public async Task<ApiResponse<List<Author>>> GetAuthors()
    {
        return await service.GetAuthors();
    }
}
