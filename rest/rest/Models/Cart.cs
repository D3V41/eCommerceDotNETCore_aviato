using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public int userId { get; set; }
        public int quantity { get; set; }
    }
}
