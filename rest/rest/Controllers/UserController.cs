using Microsoft.AspNetCore.Mvc;
using rest.Models;
using rest.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly EcommerceDBContext _context;

        public UserController(EcommerceDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        [Route("register")]
        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            var usr = _context.Users.SingleOrDefault(u => u.Email == user.Email);
            if(usr == null)
            {
                if(user.Email != null && user.Name != null && user.Password != null && user.Shipping_address != null)
                {
                    user.Salt = InCryptPassword.CreateSalt();
                    user.Password = InCryptPassword.GenerateHash(user.Password, user.Salt);
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return Created("User Created", user);
                }
                else
                {
                    return Created("Invalid", "Missing parameters");
                }
                
            }
            return Created("Found", "User exist");

        }

        [Route("login")]
        [HttpPost]
        public IActionResult LoginUser(User user)
        {
            var usr = _context.Users.SingleOrDefault(u => u.Email == user.Email);
            if (usr != null)
            {
                if(user.Email != null && user.Password != null)
                {
                    if (InCryptPassword.AreEqual(user.Password, usr.Password, usr.Salt))
                    {
                        return Created("User Loged In", "Success");
                    }
                    else
                    {
                        return Created("Error", "Wrong Password");
                    }
                }
                else
                {
                    return Created("Error", "Missing parameters");
                }
                               
            }
            return Created("Not Found", "User not exist");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usr = _context.Users.SingleOrDefault(u => u.Id == id);
            if (usr == null)
            {
                return Created("Not Found", "User not found");
            }
            _context.Users.Remove(usr);
            _context.SaveChanges();
            return Ok("User Deleted");
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            var usr = _context.Users.SingleOrDefault(u => u.Id == user.Id);
            if (usr == null)
            {
                return Created("Not Found", "User not found");
            }
            if (user.Name != null)
            {
                usr.Name = user.Name;
            }

            if (user.Email != null)
            {
                usr.Email = user.Email;
            }

            if (user.Password != null)
            {
                var salt = InCryptPassword.CreateSalt();
                var hashedPassword = InCryptPassword.GenerateHash(user.Password, salt);
                usr.Password = hashedPassword;
                usr.Salt = salt;
            }

            if (user.Shipping_address != null)
            {
                usr.Shipping_address = user.Shipping_address;
            }

            _context.Users.Update(usr);
            _context.SaveChanges();
            return Ok("User chnaged");
        }
    }
}
