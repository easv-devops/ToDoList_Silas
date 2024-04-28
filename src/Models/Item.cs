namespace Models;

public class Item
{
    public int id { get; set; }
    public string text { get; set; }
    public bool is_completed { get; set; }
    public DateTime created_date { get; set; }
    public DateTime? completed_date { get; set; }
}