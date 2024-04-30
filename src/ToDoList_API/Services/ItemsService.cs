using Dapper;
using Models;

namespace ToDoList_API.Services;

public class ItemsService
{
    public Item[] GetItems()
    {
        using var connection = DatabaseConnection.GetConnection();
        return connection.Query<Item>("SELECT * FROM Items").ToArray();
    }
    
    public Item GetItem(int id)
    {
        using var connection = DatabaseConnection.GetConnection();
        var item = connection.QueryFirstOrDefault<Item>("SELECT * FROM Items WHERE id = @id", new { id });
        if (item == null)
        {
            throw new ArgumentNullException();
        }
        return item;
    }
    
    public int CreateItem(ItemDto item)
    {
        using var connection = DatabaseConnection.GetConnection();
        using var transaction = connection.BeginTransaction();
        connection.Execute("INSERT INTO Items (text, is_completed, completed_date) VALUES (@Text, @IsCompleted, @CompletedDate)",
            new { Text = item.text, IsCompleted = item.is_completed, CompletedDate = item.completed_date }, transaction);
        int id = connection.QuerySingle<int>("SELECT LAST_INSERT_ID()", transaction);
        transaction.Commit();
        return id;
    }
    
    public void UpdateItem(int id, ItemDto item)
    {
        using var connection = DatabaseConnection.GetConnection();
        using var transaction = connection.BeginTransaction();
        connection.Execute("UPDATE Items SET text = @Text, is_completed = @IsCompleted, completed_date = @CompletedDate WHERE id = @id",
            new { Text = item.text, IsCompleted = item.is_completed, CompletedDate = item.completed_date, id }, transaction);
        transaction.Commit();
    }
    
    public void DeleteItem(int id)
    {
        using var connection = DatabaseConnection.GetConnection();
        using var transaction = connection.BeginTransaction();
        connection.Execute("DELETE FROM Items WHERE id = @id", new { id }, transaction);
        transaction.Commit();
    }
}