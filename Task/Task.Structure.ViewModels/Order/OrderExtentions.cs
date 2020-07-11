using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Structure.Entities;

namespace Task.Structure.ViewModels
{
    public static class OrderExtentions
    {
        public static OrderViewModel ToViewModel (this Order Model)
        {
           return new OrderViewModel() {
               ID = Model.ID , 
               Date = Model.Date ,
               ClientID = Model.ClientID,
               Total = Model.Total,
               OrderItems = Model.OrderItems.Select(i=>i.ToViewModel())
           };
        }
        public static Order ToModel(this OrderEditViewModel EditModel) {
            return new Order()
            {
                ID = EditModel.ID,
                Date = EditModel.Date,
                ClientID = EditModel.ClientID,
                Total = EditModel.Total ,
                OrderItems = EditModel.OrderItems.Select(i=>i.ToModel()).ToList()
            };  
        }
        public static OrderEditViewModel ToEditableViewModel(this Order Model) {
            return new OrderEditViewModel() {
                ID=Model.ID,
                Date = Model.Date,
                ClientID = Model.ClientID,
                Total = Model.Total,
                OrderItems = Model.OrderItems.Select(i => i.ToEditableViewModel()),
                ClientName = Model.Client?.Name,
            };
        }
    }
}
