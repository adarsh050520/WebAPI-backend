using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
