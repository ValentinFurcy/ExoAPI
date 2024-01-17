
using ExoAPI.Models;

namespace ExoAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task<Order> UpdateOrdertAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
    }
}
