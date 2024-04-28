using Models;
using ToDoList_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ItemsService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// app.MapGet("/items", (ItemsService itemsService) =>
//     {
//         return itemsService.GetItems();
//     })
//     .WithName("GetItems")
//     .WithOpenApi();
//
// app.MapPost("/items", (ItemsService itemsService, ItemDTO item) =>
//     {
//         itemsService.CreateItem(item);
//     })
//     .WithName("CreateItem")
//     .WithOpenApi();
//
// app.MapGet("/items/{id}", (ItemsService itemsService, int id) =>
//     {
//         return itemsService.GetItem(id);
//     })
//     .WithName("GetItem")
//     .WithOpenApi();
//
// app.MapPut("/items/{id}", (ItemsService itemsService, int id, ItemDTO item) =>
//     {
//         itemsService.UpdateItem(id, item);
//     })
//     .WithName("UpdateItem")
//     .WithOpenApi();
//
// app.MapDelete("/items/{id}", (ItemsService itemsService, int id) =>
//     {
//         itemsService.DeleteItem(id);
//     })
//     .WithName("DeleteItem")
//     .WithOpenApi();

app.Run();