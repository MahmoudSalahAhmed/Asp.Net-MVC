using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.Entities
{
    [Table("Order", Schema = "Orman")]
    public class Order : BaseModel
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Total { get; set; }
        
        public virtual Client Client { get; set; }
        [ForeignKey("Client")]
        [Required]
        public int ClientID { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
