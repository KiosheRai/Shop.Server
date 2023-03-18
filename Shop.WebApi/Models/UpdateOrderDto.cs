using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Application.Orders;

namespace Shop.WebApi.Models;

public class UpdateOrderDto
    : IMapWith<UpdateOrder>
{
    public Guid Id { get; set; }
    public bool IsCompleted { get; set; }
    public IEnumerable<Guid>? Books { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateOrderDto, UpdateOrder>()
            .ForMember(to => to.Id,
                by => by.MapFrom(from => from.Id))
            .ForMember(to => to.IsCompleted,
                by => by.MapFrom(from => from.IsCompleted))
            .ForMember(to => to.Books,
                by => by.MapFrom(from => from.Books));
    }
}
