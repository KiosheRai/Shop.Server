using Shop.Domain;

namespace Shop.Application.Orders;

public class UpdateOrder
{
    public Guid Id { get; set; }
    public bool IsCompleted { get; set; }

    public IEnumerable<Guid>? Books { get; set; }
}
