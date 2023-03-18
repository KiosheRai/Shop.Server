using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders;
using Shop.WebApi.Models;

namespace Shop.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrdersController : Controller
{
    private readonly IMapper _mapper;
    private readonly OrdersManager _ordersManager;

    public OrdersController(IMapper mapper, OrdersManager booksManager) =>
        (_mapper, _ordersManager) = (mapper, booksManager);

    /// <summary>
    /// Gets all orders
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Orders/GetAll
    /// </remarks>
    /// <returns>Returns OrdersList</returns>
    /// <response code="200">Success</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<OrdersList>> GetAll() =>
        Ok(await _ordersManager.GetAllAsync());

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
    public async Task<ActionResult<OrderDetails>> Get(Guid id) =>
        Ok(await _ordersManager.Get(id));

    /// <summary>
    /// Gets filtered orders by completed
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Orders/GetFilteredByCompleted/true
    /// </remarks>
    /// <returns>Returns OrdersList</returns>
    /// <response code="200">Success</response>
    [HttpGet("{completed}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<OrdersList>> GetFilteredByCompleted(bool completed) =>
        Ok(await _ordersManager.GetFilteredByCompleted(completed));

    /// <summary>
    /// Gets filtered orders by date
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /Orders/GetFilteredByDate/2022.02.02, 2023.02.02
    /// </remarks>
    /// <returns>Returns OrdersList</returns>
    /// <response code="200">Success</response>
    [HttpGet("{start}, {end}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<OrdersList>> GetFilteredByDate(DateTime start, DateTime end) =>
        Ok(await _ordersManager.GetFilteredByDate(start, end));


    /// <summary>
    /// Creates the order
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /Order/Create
    /// {
    ///     Books: ["C9D5C857-0CB2-4656-9AD7-9D9E010672A2","C9D5C857-0CB2-4656-9AD7-9D9E010672A2"]
    /// }
    /// </remarks>
    /// <param name="createOrder">CreateOrderDto object</param>
    /// <returns>Returns id (guid)</returns>
    /// <response code="201">Success</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create([FromBody] CreateOrderDto createOrder)
    {
        var book = _mapper.Map<CreateOrder>(createOrder);
        return Ok(await _ordersManager.CreateAsync(book));
    }

    /// <summary>
    /// Updates the order
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /Order/Update
    /// {
    ///     id: "D34D349E-43B8-429E-BCA4-793C932FD580",
    ///     isCompleted: true,
    ///     books: ["C9D5C857-0CB2-4656-9AD7-9D9E010672A2","C9D5C857-0CB2-4656-9AD7-9D9E010672A2"],
    /// }
    /// </remarks>
    /// <param name="updateOrder">UpdateOrderDto object</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Update([FromBody] UpdateOrderDto updateOrder)
    {
        var book = _mapper.Map<UpdateOrder>(updateOrder);
        await _ordersManager.UpdateAsync(book);
        return NoContent();
    }

    /// <summary>
    /// Delete the order
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /Orders/Delete/D34D349E-43B8-429E-BCA4-793C932FD580
    /// </remarks>
    /// <param name="id">Order id (guid)</param>
    /// <returns>Returns NoContent</returns>
    /// <response code="204">Success</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _ordersManager.DeleteAsync(id);
        return NoContent();
    }
}
