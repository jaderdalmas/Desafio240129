using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers;

[ApiController, Route("[controller]")]
public class BookController : ControllerBase
{
	private readonly ILogger<BookController> _logger;
	private readonly IBookRepository _repos;

	public BookController(ILogger<BookController> logger, IBookRepository repos)
	{
		_logger = logger;
		_repos = repos;
	}

	[HttpGet]
	public IEnumerable<BookModel> Get([FromQuery] string filter = "") => _repos.Get(filter);

	[HttpGet("[action]")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookModel))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult ById([FromQuery] int id)
	{
		var result = _repos.Get(id);
		return result is null ? NotFound() : Ok(result);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public IActionResult Post([FromBody] BookModel model)
	{
		var result = _repos.Post(model);
		return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
	}

	[HttpPut]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult Put([FromBody] BookModel model) => _repos.Put(model) ? NoContent() : NotFound();

	[HttpDelete]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public IActionResult Delete([FromQuery] int id) => _repos.Delete(id) ? NoContent() : NotFound();
}