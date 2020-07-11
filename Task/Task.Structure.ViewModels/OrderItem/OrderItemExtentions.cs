using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Structure.Entities;

namespace Task.Structure.ViewModels
{
    public static class OrderItemExtentions
    {
        public static OrderItemViewModel ToViewModel (this OrderItem Model)
        {
           return new OrderItemViewModel() {
               ID = Model.ID , 
               Quantity = Model.Quantity ,
               OrderID = Model.OrderID ,
               ItemID = Model.ItemID
           };
        }
        public static OrderItem ToModel(this OrderItemEditViewModel EditModel) {
            return new OrderItem()
            {
                ID = EditModel.ID,
                Quantity = EditModel.Quantity,
                OrderID = EditModel.OrderID,
                ItemID = EditModel.ItemID
            };  
        }
        public static OrderItemEditViewModel ToEditableViewModel(this OrderItem Model) {
            return new OrderItemEditViewModel() {
                ID = Model.ID,
                Quantity = Model.Quantity,
                OrderID = Model.OrderID,
                ItemID = Model.ItemID
            };
        }
    }
}
