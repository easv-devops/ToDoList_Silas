using MySqlConnector;

namespace ToDoList_API.Services;

public static class DatabaseConnection
{
    public static MySqlConnection GetConnection()
    {
        var connection = new MySqlConnection("Server=mariadb;Database=todolist;Uid=myuser;Pwd=mypassword;");
        connection.Open();
        return connection;
    }
}