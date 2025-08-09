using Library_Management_Api.Model;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly ContextHome _ctx;
    public AuthorsController(ContextHome ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<IEnumerable<Author>> Get() =>
        await _ctx.Authors.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Author>> Post(Author author)
    {
        _ctx.Authors.Add(author);
        await _ctx.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = author.Id }, author);
    }
}
