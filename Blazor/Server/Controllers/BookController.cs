using Blazor.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IHttpClientFactory _factory;

    public BookController(ILogger<BookController> logger, IHttpClientFactory factory)
    {
        _logger = logger;
        _factory = factory;
    }

    [HttpGet]
    public async Task<IEnumerable<BookModel>> Get([FromQuery]string filter = "")
    {
        var query = string.IsNullOrEmpty(filter) ? string.Empty : $"?filter={filter}";
        var result = await _factory.CreateClient().GetFromJsonAsync<IEnumerable<BookModel>>($"https://localhost:32774/Book{query}");
        return result ?? new List<BookModel>();
    }
}