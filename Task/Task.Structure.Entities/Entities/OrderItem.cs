using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.Entities
{
    [Table("OrderItem", Schema = "Orman")]
    public class OrderItem : BaseModel
    {
        [Required]
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public virtual Item Item { get; set; }
        [Required]
        [ForeignKey("Item")]
        public int ItemID { get; set; }
    }
}
