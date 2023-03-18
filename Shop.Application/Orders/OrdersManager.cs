using AutoMapper;
using Shop.Application.Books;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;
using System.Linq;

namespace Shop.Application.Orders;

public class OrdersManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrdersManager(IUnitOfWork unitOfWork, IMapper mapper) =>
        (_unitOfWork, _mapper) = (unitOfWork, mapper);


    public async Task<OrdersList> GetAllAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        return new OrdersList
        {
            Orders = orders.Select(x => _mapper.Map<OrderDto>(x))
        };
    }

    public async Task<OrderDetails> Get(Guid id)
    {
        var order = await _unitOfWork.Orders.FirstOrDefaultAsync(order => order.Id == id)
            ?? throw new NotFoundException(nameof(id), typeof(Order));


        return _mapper.Map<OrderDetails>(order);
    }

    public async Task<OrdersList> GetFilteredByCompleted(bool isCompleted)
    {
        var orders = await _unitOfWork.Orders.GetFiltered(order => order.IsCompleted == isCompleted);

        return new OrdersList
        {
            Orders = orders?.Select(x => _mapper.Map<OrderDto>(x))
        };
    }

    public async Task<OrdersList> GetFilteredByDate(DateTime start, DateTime end)
    {
        var orders = await _unitOfWork.Orders.GetFiltered(order => order.OrderDate > start && order.OrderDate < end);

        return new OrdersList
        {
            Orders = orders?.Select(x => _mapper.Map<OrderDto>(x))
        };
    }

    public async Task<Guid> CreateAsync(CreateOrder createOrder)
    {
        var books = createOrder.Books is not null
            ? await _unitOfWork.Books.GetRange(x => createOrder.Books.Contains(x.Id))
            : null;

        var order = new Order
        {
            Id = Guid.NewGuid(),
            OrderDate = DateTime.Today,
            IsCompleted = false,
            Books = books,
        };

        await _unitOfWork.Orders.CreateAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return order.Id;
    }

    public async Task UpdateAsync(UpdateOrder updateOrder)
    {
        var order = await _unitOfWork.Orders.FirstOrDefaultAsync(order => order.Id == updateOrder.Id)
            ?? throw new NotFoundException(nameof(updateOrder.Id), typeof(Order));

        var books = updateOrder.Books is not null
            ? await _unitOfWork.Books.GetRange(x => updateOrder.Books.Contains(x.Id))
            : null;

        order.IsCompleted = updateOrder.IsCompleted;
        order.Books = books;

        await _unitOfWork.SaveChangesAsync();   
    }

    public async Task DeleteAsync(Guid id)
    {
        var order = await _unitOfWork.Orders.FirstOrDefaultAsync(order => order.Id == id)
            ?? throw new NotFoundException(nameof(id), typeof(Book));
        _unitOfWork.Orders.Remove(order);
        await _unitOfWork.SaveChangesAsync();
    }
}