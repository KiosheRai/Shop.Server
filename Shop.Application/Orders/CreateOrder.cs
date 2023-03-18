using Shop.Domain;

namespace Shop.Application.Orders;

public class CreateOrder
{
    public IEnumerable<Guid>? Books { get; set; }
}
