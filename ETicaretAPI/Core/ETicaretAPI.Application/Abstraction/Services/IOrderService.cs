using ETicaretAPI.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstraction.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder createOrder);
        Task<ListOrder> GetAllOrdesAsync(int page,int size);
        Task<SingleOrder> GetOrderByIdAsync(string id);
        Task <(bool,CompletedOrderDTO)> CompleteOrderAsync(string id);
    }
}
