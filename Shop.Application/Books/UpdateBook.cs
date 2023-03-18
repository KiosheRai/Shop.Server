using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Books;

public class UpdateBook
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = null!;
    [Required]
    [MaxLength(255)]
    public string Description { get; set; } = null!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public DateTime ReleaseDate { get; set; }
}
