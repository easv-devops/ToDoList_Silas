using Dapper;
using Models;

namespace ToDoList_API.Services;

public class HistoryService
{
    public History[] GetHistories()
    {
        using var connection = DatabaseConnection.GetConnection();
        return connection.Query<History>("SELECT * FROM History").ToArray();
    }
    
    public History GetHistory(int id)
    {
        using var connection = DatabaseConnection.GetConnection();
        var history = connection.QueryFirstOrDefault<History>("SELECT * FROM History WHERE id = @id", new { id });
        if (history == null)
        {
            throw new ArgumentNullException();
        }
        return history;
    }
    
    public void CreateHistory(HistoryDto history)
    {
        using var connection = DatabaseConnection.GetConnection();
        using var transaction = connection.BeginTransaction();
        connection.Execute("INSERT INTO History (text, item_id) VALUES (@Text, @ItemId)",
            new { Text = history.text, IsCompleted = history.item_id }, transaction);
        transaction.Commit();
    }
    
    public void UpdateHistory(int id, HistoryDto history)
    {
        using var connection = DatabaseConnection.GetConnection();
        using var transaction = connection.BeginTransaction();
        connection.Execute("UPDATE History SET text = @Text WHERE id = @id",
            new { Text = history.text, id }, transaction);
        transaction.Commit();
    }
    
    public void DeleteHistory(int id)
    {
        using var connection = DatabaseConnection.GetConnection();
        using var transaction = connection.BeginTransaction();
        connection.Execute("DELETE FROM History WHERE id = @id", new { id }, transaction);
        transaction.Commit();
    }
}