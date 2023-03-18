using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Domain;

namespace Shop.Application.Orders;

public class OrderDto
    : IMapWith<Order>
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsCompleted { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderDto>()
            .ForMember(to => to.Id,
                by => by.MapFrom(from => from.Id))
            .ForMember(to => to.OrderDate,
                by => by.MapFrom(from => from.OrderDate))
            .ForMember(to => to.IsCompleted,
                by => by.MapFrom(from => from.IsCompleted));
    }
}
