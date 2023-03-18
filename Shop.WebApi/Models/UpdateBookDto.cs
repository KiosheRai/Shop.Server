using AutoMapper;
using Shop.Application.Books;
using Shop.Application.Common.Mappings;

namespace Shop.WebApi.Models;

public class UpdateBookDto
    : IMapWith<UpdateBook>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateBookDto, UpdateBook>()
            .ForMember(to => to.Id,
                by => by.MapFrom(from => from.Id))
            .ForMember(to => to.Name,
                by => by.MapFrom(from => from.Name))
            .ForMember(to => to.Description,
                by => by.MapFrom(from => from.Description))
            .ForMember(to => to.Price,
                by => by.MapFrom(from => from.Price))
            .ForMember(to => to.ReleaseDate,
                by => by.MapFrom(from => from.ReleaseDate));
    }
}
