using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.ViewModels
{
    public class GroupEditViewModel
    {
        [Required(ErrorMessage = "This Field Is Required")]
        public int ID { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public string Name { get; set; }
    }
}
