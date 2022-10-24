using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest.Models
{
    public class Banner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Src { get; set; }
    }
}
