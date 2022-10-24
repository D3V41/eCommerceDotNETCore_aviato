using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int productId { get; set; }
        public int userId { get; set; }
        public string date { get; set; }
        public string username { get; set; }
        public string review { get; set; }
        public string Src { get; set; }
    }
}
