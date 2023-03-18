using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain;

namespace Shop.Application.Orders;

public class OrderDetails 
    : IMapWith<Order>
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsCompleted { get; set; }

    public IEnumerable<Book>? Books { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderDetails>()
            .ForMember(to => to.Id,
                by => by.MapFrom(from => from.Id))
            .ForMember(to => to.OrderDate,
                by => by.MapFrom(from => from.OrderDate))
            .ForMember(to => to.IsCompleted,
                by => by.MapFrom(from => from.IsCompleted))
            .ForMember(to => to.Books,
                by => by.MapFrom(from => from.Books));
    }

}
