using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Application.Orders;

namespace Shop.WebApi.Models;

public class CreateOrderDto
    : IMapWith<CreateOrder>
{
    public IEnumerable<Guid>? Books { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderDto, CreateOrder>()
            .ForMember(to => to.Books,
                by => by.MapFrom(from => from.Books));
    }
}
