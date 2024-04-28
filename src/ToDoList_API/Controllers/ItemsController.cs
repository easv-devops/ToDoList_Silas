using Microsoft.AspNetCore.Mvc;
using Models;
using ToDoList_API.Services;
using Microsoft.AspNetCore.OpenApi;

namespace ToDoList_API.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ItemsService _itemsService;

    public ItemsController(ItemsService itemsService)
    {
        _itemsService = itemsService;
    }

    [HttpGet]
    public IActionResult GetItems()
    {
        return Ok(_itemsService.GetItems());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetItem(int id)
    {
        try
        {
            return Ok(_itemsService.GetItem(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public IActionResult CreateItem(ItemDTO item)
    {
        _itemsService.CreateItem(item);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateItem(int id, ItemDTO item)
    {
        try
        {
            _itemsService.UpdateItem(id, item);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteItem(int id)
    {
        try
        {
            _itemsService.DeleteItem(id);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}