namespace Shop.Domain;

public class Order
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsCompleted { get; set; }

    public IEnumerable<Book>? Books { get; set; }
}
