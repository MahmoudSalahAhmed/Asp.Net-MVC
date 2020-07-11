using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Structure.ViewModels
{
    public class ItemEditViewModel
    {
        [Required(ErrorMessage = "This Field Is Required")]
        public int ID { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public decimal Price { get; set; }
    }
}
