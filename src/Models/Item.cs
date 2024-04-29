namespace Models;

public class Item
{
    public Item (int id, string text, bool is_completed, DateTime created_date, DateTime? completed_date)
    {
        this.id = id;
        this.text = text;
        this.is_completed = is_completed;
        this.created_date = created_date;
        this.completed_date = completed_date;
    }
    
    public Item () {}
    
    public int id { get; set; }
    public string? text { get; set; }
    public bool is_completed { get; set; }
    public DateTime? created_date { get; set; }
    public DateTime? completed_date { get; set; }
}