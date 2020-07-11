using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Structure.Entities;

namespace Task.Structure.ViewModels
{
    public static class ItemExtentions
    {
        public static ItemViewModel ToViewModel (this Item Model)
        {
           return new ItemViewModel() {
               ID = Model.ID , 
               Name = Model.Name ,
               Price = Model.Price
           };
        }
        public static Item ToModel(this ItemEditViewModel EditModel) {
            return new Item()
            {
                ID = EditModel.ID ,
                Name = EditModel.Name,
                Price = EditModel.Price
            };  
        }
        public static ItemEditViewModel ToEditableViewModel(this Item Model) {
            return new ItemEditViewModel() {
                ID=Model.ID,
                Name = Model.Name ,
                Price = Model.Price
            };
        }
    }
}
