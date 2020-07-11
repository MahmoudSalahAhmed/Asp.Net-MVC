using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.Entities
{
    [Table("Client", Schema = "Orman")]
    public class Client : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public virtual Group Group { get; set; }
        [ForeignKey("Group")]
        [Required]
        public int GroupID { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
