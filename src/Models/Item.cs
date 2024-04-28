namespace Models;

public record Item(int Id, string Text, bool IsCompleted, DateTime CreatedDate, DateTime CompletedDate)
{
}