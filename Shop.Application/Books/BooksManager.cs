using AutoMapper;
using AutoMapper.QueryableExtensions;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;
using static System.Reflection.Metadata.BlobBuilder;

namespace Shop.Application.Books;

public class BooksManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BooksManager(IUnitOfWork unitOfWork, IMapper mapper) =>
        (_unitOfWork, _mapper) = (unitOfWork, mapper);


    public async Task<BooksList> GetAllAsync()
    {
        var books = await _unitOfWork.Books.GetAllAsync();
        return new BooksList
        {
            Books = books.Select(x => _mapper.Map<BookDto>(x))
        };
    }

    public async Task<BookDetails> Get(Guid id)
    {
        var book = await _unitOfWork.Books.FirstOrDefaultAsync(book => book.Id == id)
            ?? throw new NotFoundException(nameof(id), typeof(Book));
    

        return _mapper.Map<BookDetails>(book);
    }

    public async Task<BooksList> GetFilteredByName(string name)
    {
        var books = await _unitOfWork.Books.GetFiltered(book => book.Name.Contains(name));

        return new BooksList
        {
            Books = books?.Select(x => _mapper.Map<BookDto>(x))
        };
    }

    public async Task<BooksList> GetFilteredByDate(DateTime start, DateTime end)
    {
        var books = await _unitOfWork.Books.GetFiltered(book => book.ReleaseDate > start && book.ReleaseDate < end);

        return new BooksList
        {
            Books = books?.Select(x => _mapper.Map<BookDto>(x))
        };
    }

    public async Task<Guid> CreateAsync(CreateBook createBook)
    {
        var book = new Book
        {
            Id = Guid.NewGuid(),
            Name = createBook.Name,
            Description = createBook.Description,
            Price = createBook.Price,
            ReleaseDate = createBook.ReleaseDate,
            Orders = null
        };

        await _unitOfWork.Books.CreateAsync(book);
        await _unitOfWork.SaveChangesAsync();
        return book.Id;
    }

    public async Task UpdateAsync(UpdateBook updateBook)
    {
        var book = await _unitOfWork.Books.FirstOrDefaultAsync(book => book.Id == updateBook.Id)
            ?? throw new NotFoundException(nameof(updateBook.Id), typeof(Book));

        book.Name = updateBook.Name;
        book.Description = updateBook.Description;
        book.Price = updateBook.Price;
        book.ReleaseDate = updateBook.ReleaseDate;
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await _unitOfWork.Books.FirstOrDefaultAsync(book => book.Id == id)
            ?? throw new NotFoundException(nameof(id), typeof(Book));

        _unitOfWork.Books.Remove(book);
        await _unitOfWork.SaveChangesAsync();
    }
}