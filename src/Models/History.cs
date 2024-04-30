namespace Models;

public class History
{
    public History (int id, int item_id, DateTime created_date, string text)
    {
        this.id = id;
        this.item_id = item_id;
        this.created_date = created_date;
        this.text = text;
    }
    
    public History () {}
    
    public int id { get; set; }
    public int item_id { get; set; }
    public DateTime? created_date { get; set; }
    public string? text { get; set; }
}