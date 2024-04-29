using Moq;
using ToDoList_API.Controllers;
using ToDoList_API.Services;
using Models;

namespace ToDoList_API_Tests;

[TestFixture]
public class ItemsControllerTests
{
    private Mock<ItemsService> _mockItemsService;
    private ItemsController _controller;

    [SetUp]
    public void Setup()
    {
        _mockItemsService = new Mock<ItemsService>();
        _controller = new ItemsController(_mockItemsService.Object);
    }
}