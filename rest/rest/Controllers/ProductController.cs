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
    public class ProductController:ControllerBase
    {
        private readonly EcommerceDBContext _context;

        public ProductController(EcommerceDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return _context.Products.SingleOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var prd = _context.Products.SingleOrDefault(p => p.Type == product.Type && p.Title == product.Title);
            if (prd == null)
            {
                if(product.Title != null && product.Details != null && product.Type != null && product.oldPrice != 0 && product.newPrice != 0 && product.Src != null)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return Created("Product Created", product);
                }
                else
                {
                    return Created("Error", "Missing parameters");
                }
               
            }
            return Created("Found", "Product exist");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prd = _context.Products.SingleOrDefault(p => p.Id == id);
            if (prd == null)
            {
                return Created("Not Found", "Product not found");
            }
            _context.Products.Remove(prd);
            _context.SaveChanges();
            return Ok("Product Deleted");
        }

        [HttpPut]
        public IActionResult Update(Product product)
        {
            var prd = _context.Products.SingleOrDefault(p => p.Id == product.Id);
            if (prd == null)
            {
                return Created("Not Found", "Product not found");
            }
            if (product.Title != null)
            {
                prd.Title = product.Title;
            }

            if (product.Details != null)
            {
                prd.Details = product.Details;
            }

            if (product.oldPrice != 0)
            {
                prd.oldPrice = product.oldPrice;
            }

            if (product.newPrice != 0)
            {
                prd.newPrice = product.newPrice;
            }

            if (product.Src != null)
            {
                prd.Src = product.Src;
            }

            if (product.Type != null)
            {
                prd.Type = product.Type;
            }

            _context.Products.Update(prd);
            _context.SaveChanges();
            return Ok("Product chnaged");
        }
    }
}
