﻿using Dapper;
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
            throw new Exception("Item not found");
        }
        return item;
    }
    
    public void CreateItem(ItemDTO item)
    {
        using var connection = DatabaseConnection.GetConnection();
        using var transaction = connection.BeginTransaction();
        connection.Execute("INSERT INTO Items (text, is_completed, completed_date) VALUES (@Text, @IsCompleted, @CompletedDate)",
                           new { item.text, item.is_completed, item.completed_date }, transaction);
        transaction.Commit();
    }
    
    public void UpdateItem(int id, ItemDTO item)
    {
        using var connection = DatabaseConnection.GetConnection();
        using var transaction = connection.BeginTransaction();
        connection.Execute("UPDATE Items SET text = @Text, is_completed = @IsCompleted, completed_date = @CompletedDate WHERE id = @id",
                           new { item.text, item.is_completed, item.completed_date, id }, transaction);
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