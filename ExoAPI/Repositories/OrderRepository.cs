using ExoAPI.Context;
using ExoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExoAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        ExoAPIContext context;

        public OrderRepository(ExoAPIContext exoAPIContext) 
        {
            context = exoAPIContext;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            try
            {
                var orderToDelete = context.Orders.FirstOrDefault(o => o.Id == id);
                context.Orders.Remove(orderToDelete);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Order>> GetAllAsync()
        {
           return await context.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await context.Orders.FindAsync(id);
        }

        public async Task<Order> UpdateOrdertAsync(Order order)
        {
            var orderUpdate = context.Orders.FirstOrDefault(o => o.Id == order.Id);

            orderUpdate.Number = orderUpdate.Number;
            await context.SaveChangesAsync();

            return order;
        }

    }
}
