namespace Models;

public record ItemDto(string? text, bool is_completed, DateTime? completed_date)
{
}