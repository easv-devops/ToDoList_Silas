using Microsoft.AspNetCore.Mvc;
using Models;
using ToDoList_API.Services;

namespace ToDoList_API.Controllers;

[ApiController]
[Route("[controller]")]
public class HistoryController : ControllerBase
{
    private readonly HistoryService _historyService;

    public HistoryController(HistoryService historyService)
    {
        _historyService = historyService;
    }
    
    [HttpGet]
    public History[] GetHistories()
    {
        return _historyService.GetHistories();
    }
    
    [HttpGet("{id}")]
    public History GetHistory(int id)
    {
        return _historyService.GetHistory(id);
    }
    
    [HttpPost]
    public ActionResult CreateHistory(HistoryDto history)
    {
        _historyService.CreateHistory(history);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateHistory(int id, HistoryDto history)
    {
        _historyService.UpdateHistory(id, history);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteHistory(int id)
    {
        _historyService.DeleteHistory(id);
        return Ok();
    }
}