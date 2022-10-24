using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public double oldPrice { get; set; }
        public double newPrice { get; set; }
        public string Src { get; set; }
    }
}
