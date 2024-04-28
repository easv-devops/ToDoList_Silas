namespace Models;

public record ItemDTO(string text, bool is_completed, DateTime? completed_date)
{
}