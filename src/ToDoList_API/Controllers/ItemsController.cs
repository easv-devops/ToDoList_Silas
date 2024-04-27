using Microsoft.AspNetCore.Mvc;

namespace ToDoList_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{

    private readonly ILogger<ItemsController> _logger;

    public ItemsController(ILogger<ItemsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetItems")]
    public IActionResult Get()
    {
        return Ok();
    }
}