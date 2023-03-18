using AutoMapper;
using Shop.Application.Books;
using Shop.Application.Common.Mappings;

namespace Shop.WebApi.Models;

public class CreateBookDto
    : IMapWith<CreateBook>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateBookDto, CreateBook>()
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
