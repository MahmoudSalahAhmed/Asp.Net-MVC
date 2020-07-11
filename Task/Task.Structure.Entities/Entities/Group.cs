using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.Entities
{
    [Table("Group" , Schema = "Orman")]
    public class Group : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
