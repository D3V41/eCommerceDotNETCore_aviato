using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public string address { get; set; }
        public double price { get; set; }
    }
}
