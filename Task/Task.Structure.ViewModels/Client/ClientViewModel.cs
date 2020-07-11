using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.ViewModels
{
    public class ClientViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int GroupID { get; set; }
        public GroupViewModel Group  { get; set; }
    }
}
