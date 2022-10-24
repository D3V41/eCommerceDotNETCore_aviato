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
    public class ReviewController : ControllerBase
    {
        private readonly EcommerceDBContext _context;
        public ReviewController(EcommerceDBContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public Review GetCartById(int id)
        {
            return _context.Reviews.SingleOrDefault(r => r.Id == id);
        }

        [HttpGet("product/{id}")]
        public List<Review> GetReviewsByProductId(int id)
        {
            return (List<Review>)_context.Reviews.Where(r => r.productId == id).ToList();
        }

        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            var rv = _context.Reviews.SingleOrDefault(r => r.userId == review.userId && r.productId == review.productId);  
            if (rv == null)
            {
                if (review.review != null)
                {
                    _context.Reviews.Add(review);
                    _context.SaveChanges();
                    return Created("Review Added", review);
                }
                else
                {
                    return Created("Error", "Missing parameters");
                }

            }
            return Created("Found", "Review already Added");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var rv = _context.Reviews.SingleOrDefault(r => r.Id == id);
            if (rv == null)
            {
                return Created("Not Found", "Review not found");
            }
            _context.Reviews.Remove(rv);
            _context.SaveChanges();
            return Ok("Review Deleted");
        }

        [HttpPut]
        public IActionResult Update(Review review)
        {
            var rv = _context.Reviews.SingleOrDefault(r => r.Id == review.Id);
            if (rv == null)
            {
                return Created("Not Found", "Review not found");
            }
            if (rv.review != null)
            {
                rv.review = review.review;
            }
            _context.Reviews.Update(rv);
            _context.SaveChanges();
            return Ok("Review changed");
        }
    }
}
