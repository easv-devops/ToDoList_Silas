using ToDoList_Front.Clients;
using ToDoList_Front.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiUrl = builder.Configuration["TodoListApiUrl"] ?? 
             throw new ArgumentNullException();

builder.Services.AddHttpClient<ItemsClient>(client =>
{
    client.BaseAddress = new Uri(apiUrl);
});

builder.Services.AddHttpClient<HistoryClient>(client =>
{
    client.BaseAddress = new Uri(apiUrl);
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAntiforgery();

app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();