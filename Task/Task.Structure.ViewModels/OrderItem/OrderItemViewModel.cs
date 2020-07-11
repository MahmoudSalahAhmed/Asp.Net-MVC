using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.ViewModels
{
    public class OrderItemViewModel
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }

    }
}
