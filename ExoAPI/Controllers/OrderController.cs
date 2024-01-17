using ExoAPI.Models;
using ExoAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderRepository orderRepository;

        public OrderController(IOrderRepository IOrderRepository)
        {
            orderRepository = IOrderRepository;
        }

        /// <summary>
        /// Get All Order
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await orderRepository.GetAllAsync());
        }

       /// <summary>
       /// Get By ID 
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet("GetOrderById/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            return Ok(await orderRepository.GetByIdAsync(id));
        }
        /// <summary>
        /// Create Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> PostOrder(Order order)
        {
            if(order != null) 
            {
                return Ok(await orderRepository.CreateOrderAsync(order));
            }
            else { return BadRequest("Echec de la création de l'order"); }

        }

        [HttpPut()]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            return Ok(await orderRepository.UpdateOrdertAsync(order));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            bool success = await orderRepository.DeleteOrderAsync(id);
            if (success)
            {
                return Ok();
            }
            else return BadRequest("Echec de la suppression");
        }
    }
}
