using Library_Management_Api.Model;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly ContextHome _ctx;
    public BooksController(ContextHome ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<IEnumerable<object>> Get()
    {
        return await _ctx.Books
            .Include(b => b.Author)
            .Include(b => b.Category)
            .Select(b => new {
                b.Id,
                b.Title,
                b.Description,
                b.PublicationYear,
                AuthorName = b.Author.Name,
                CategoryName = b.Category.Name
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> Get(int id)
    {
        var book = await _ctx.Books
            .Include(b => b.Author)
            .Include(b => b.Category)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> Post(Book book)
    {
        _ctx.Books.Add(book);
        await _ctx.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }
}
