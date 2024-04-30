using Microsoft.AspNetCore.Mvc;
using Models;
using ToDoList_API.Services;

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
    public Item[] GetItems()
    {
        return _itemsService.GetItems();
    }
    
    [HttpGet("{id}")]
    public Item GetItem(int id)
    {
        return _itemsService.GetItem(id);
    }
    
    [HttpPost]
    public ActionResult<int> CreateItem(ItemDto item)
    {
        var createdItemId = _itemsService.CreateItem(item);
        return Ok(createdItemId);
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateItem(int id, ItemDto item)
    {
        _itemsService.UpdateItem(id, item);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteItem(int id)
    {
        _itemsService.DeleteItem(id);
        return Ok();
    }
}