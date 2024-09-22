namespace TransactionAPI.Models;

public class ItemDto
{
    public string? partneritemref { get; set; }
    public string? name { get; set; }
    public int? qty { get; set; }
    public long? unitprice { get; set; }
}