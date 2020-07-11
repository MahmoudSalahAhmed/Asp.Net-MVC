using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.ViewModels
{
    public class OrderEditViewModel
    {
        
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int ClientID { get; set; }
        public  string ClientName  { get; set; }
        public decimal Total { get; set; }
        public IEnumerable<OrderItemEditViewModel> OrderItems { get; set; }
    }
}
