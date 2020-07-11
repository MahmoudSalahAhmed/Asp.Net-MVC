using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}