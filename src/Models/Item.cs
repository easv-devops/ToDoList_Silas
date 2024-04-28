namespace Models;

public record Item(int id, string text, bool is_completed, DateTime created_date, DateTime? completed_date)
{
}