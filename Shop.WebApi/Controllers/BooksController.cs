using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Books;
using Shop.WebApi.Models;

namespace Shop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BooksController : Controller
{
    private readonly IMapper _mapper;
    private readonly BooksManager _booksManager;

    public BooksController(IMapper mapper, BooksManager booksManager) =>
        (_mapper, _booksManager) = (mapper, booksManager);

    /// <summary>
    /// Gets all books
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Books/GetAll
    /// </remarks>
    /// <returns>Returns BooksList</returns>
    /// <response code="200">Success</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BooksList>> GetAll() =>
        Ok(await _booksManager.GetAllAsync());

    /// <summary>
    /// Gets book by id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Books/Get/491C4F6B-6D6F-46D7-86D1-4AA1D099165D
    /// </remarks>
    /// <returns>Returns BookDetails</returns>
    /// <response code="200">Success</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BookDetails>> Get(Guid id) =>
        Ok(await _booksManager.Get(id));

    /// <summary>
    /// Gets filtered books by name
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Books/GetFilteredByName/491C4F6B-6D6F-46D7-86D1-4AA1D099165D
    /// </remarks>
    /// <returns>Returns BookDetails</returns>
    /// <response code="200">Success</response>
    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BooksList>> GetFilteredByName(string name) =>
        Ok(await _booksManager.GetFilteredByName(name));

    /// <summary>
    /// Gets filtered books by date
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Books/GetFilteredByDate/2022.02.02, 2023.02.02
    /// </remarks>
    /// <returns>Returns BooksList</returns>
    /// <response code="200">Success</response>
    [HttpGet("{start}, {end}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BooksList>> GetFilteredByDate(DateTime start, DateTime end) =>
        Ok(await _booksManager.GetFilteredByDate(start, end));

    /// <summary>
    /// Creates the book
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /Book/Create
    /// {
    ///     name: "name",
    ///     description: "description",
    ///     price: 1234,
    ///     ReleaseDate: "2022.02.03",
    /// }
    /// </remarks>
    /// <param name="createBook">CreateBookDto object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201">Success</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create([FromBody] CreateBookDto createBook)
    {
        var book = _mapper.Map<CreateBook>(createBook);
        return Ok(await _booksManager.CreateAsync(book));
    }

    /// <summary>
    /// Updates the book
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /book/Update
    /// {
    ///     id: "D34D349E-43B8-429E-BCA4-793C932FD580"
    ///     name: "name",
    ///     description: "description"
    ///     price: 1234,
    ///     ReleaseDate: "2022.02.03",
    /// }
    /// </remarks>
    /// <param name="updateBlock">UpdateBlockDto object</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Update([FromBody] UpdateBookDto updateBook)
    {
        var book = _mapper.Map<UpdateBook>(updateBook);
        await _booksManager.UpdateAsync(book);
        return NoContent();
    }

    /// <summary>
    /// Delete the Book
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /Book/Delete/D34D349E-43B8-429E-BCA4-793C932FD580
    /// </remarks>
    /// <param name="id">Book id (guid)</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _booksManager.DeleteAsync(id);
        return NoContent();
    }
}
