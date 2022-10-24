using Microsoft.AspNetCore.Mvc;
using rest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly EcommerceDBContext _context;
        public OrderController(EcommerceDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        [HttpGet("{id}")]
        public List<Order> GetOrderByUserId(int id)
        {
            return (List<Order>)_context.Orders.Where(o => o.userId == id).ToList();
        }

        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
                if (order.quantity != 0)
                {
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                    return Created("Order Created", order);
                }
                else
                {
                    return Created("Error", "Missing parameters");
                }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ord = _context.Orders.SingleOrDefault(o => o.Id == id);
            if (ord == null)
            {
                return Created("Not Found", "Order item not found");
            }
            _context.Orders.Remove(ord);
            _context.SaveChanges();
            return Ok("Order Cancelled");
        }
    }
}
