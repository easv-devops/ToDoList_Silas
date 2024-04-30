namespace Models;

public class History
{
    public History (int id, string item_text, DateTime created_date, string text)
    {
        this.id = id;
        this.item_text = item_text;
        this.created_date = created_date;
        this.text = text;
    }
    
    public History () {}
    
    public int id { get; set; }
    public string? item_text { get; set; }
    public DateTime? created_date { get; set; }
    public string? text { get; set; }
}