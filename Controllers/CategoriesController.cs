using Library_Management_Api.Model;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ContextHome _ctx;
    public CategoriesController(ContextHome ctx) => _ctx = ctx;

    [HttpGet]
    public async Task<IEnumerable<Category>> Get() =>
        await _ctx.Categories.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Category>> Post(Category category)
    {
        _ctx.Categories.Add(category);
        await _ctx.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
    }
}
