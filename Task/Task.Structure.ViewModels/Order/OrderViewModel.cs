using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.ViewModels
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public int ClientID { get; set; }
        public IEnumerable<OrderItemViewModel> OrderItems { get; set; }
    }
}
