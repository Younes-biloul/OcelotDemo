using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OselotDemo.OrderWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OselotDemo.OrderWebApi.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly List<Order> _orders = new List<Order>();

        [HttpGet]
        [Authorize]
        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        public IActionResult PlaceOrder(Order order)
        {
            var neworder = new Order()
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                OrderItems = order.OrderItems,
                CustomerName = order.CustomerName,
                
            };

             _orders.Add(neworder);
            return Ok(neworder);
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetOrderById(int id)
        {
            var order = _orders.Find(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="admin")]

        public IActionResult CancelOrder(int id)
        {
            var order = _orders.Find(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            _orders.Remove(order);
            return NoContent();
        }
    }

}
