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
    public class CartController : ControllerBase
    {
        private readonly EcommerceDBContext _context;
        public CartController(EcommerceDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Cart> GetCarts()
        {
            return _context.Carts.ToList();
        }

        [HttpGet("{id}")]
        public List<Cart> GetCartById(int id)
        {
          return (List<Cart>)_context.Carts.Where(c => c.userId == id).ToList();
        }

        [HttpPost]
        public IActionResult AddCart (Cart cart)
        {
            var crt = _context.Carts.SingleOrDefault(c => c.userId == cart.userId && c.productId == c.productId);
            if (crt == null)
            {
                if (cart.quantity != 0)
                {
                    _context.Carts.Add(cart);
                    _context.SaveChanges();
                    return Created("Cart Created", cart);
                }
                else
                {
                    return Created("Error", "Missing parameters");
                }

            }
            return Created("Found", "Product already Added");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var crt = _context.Carts.SingleOrDefault(c => c.Id == id);
            if (crt == null)
            {
                return Created("Not Found", "Cart item not found");
            }
            _context.Carts.Remove(crt);
            _context.SaveChanges();
            return Ok("Product Deleted");
        }

        [HttpPut]
        public IActionResult Update(Cart cart)
        {
            var crt = _context.Carts.SingleOrDefault(c => c.Id == cart.Id);
            if (crt == null)
            {
                return Created("Not Found", "Cart not found");
            }
            if (cart.quantity != 0)
            {
                crt.quantity = cart.quantity;
            }
            _context.Carts.Update(crt);
            _context.SaveChanges();
            return Ok("Quantity changed");
        }
    }
}
