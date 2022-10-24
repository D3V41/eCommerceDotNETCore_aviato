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
    public class BannerController: ControllerBase
    {
        private readonly EcommerceDBContext _context;

        public BannerController(EcommerceDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Banner> GetBanners()
        {
            return _context.Banners.ToList();
        }

        [HttpGet("{id}")]
        public Banner GetBannerById(int id)
        {
            return _context.Banners.SingleOrDefault(b => b.Id == id);
        }

        [HttpPost]
        public IActionResult AddProduct(Banner banner)
        {
            var ban = _context.Banners.SingleOrDefault(b => b.Name == banner.Name && b.Title == banner.Title);
            if (ban == null)
            {
                if (banner.Title != null && banner.Name != null && banner.Subtitle != null && banner.Src != null)
                {
                    _context.Banners.Add(banner);
                    _context.SaveChanges();
                    return Created("Banner Created", banner);
                }
                else
                {
                    return Created("Error", "Missing parameters");
                }

            }
            return Created("Found", "Banner exist");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ban = _context.Banners.SingleOrDefault(b => b.Id == id);
            if (ban == null)
            {
                return Created("Not Found", "Banner not found");
            }
            _context.Banners.Remove(ban);
            _context.SaveChanges();
            return Ok("Banner Deleted");
        }

        [HttpPut]
        public IActionResult Update(Banner banner)
        {
            var ban = _context.Banners.SingleOrDefault(b => b.Id == banner.Id);
            if (ban == null)
            {
                return Created("Not Found", "Banner not found");
            }
            if (banner.Title != null)
            {
                ban.Title = banner.Title;
            }

            if (banner.Name != null)
            {
                ban.Name = banner.Name;
            }

            if (banner.Subtitle != null)
            {
                ban.Subtitle = banner.Subtitle;
            }

            if (banner.Src != null)
            {
                ban.Src = banner.Src;
            }

            _context.Banners.Update(ban);
            _context.SaveChanges();
            return Ok("Banner chnaged");
        }
    }
}
