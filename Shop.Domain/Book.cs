using System.Text.Json.Serialization;

namespace Shop.Domain;

public class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    [JsonIgnore]
    public IEnumerable<Order>? Orders { get; set; }
}
