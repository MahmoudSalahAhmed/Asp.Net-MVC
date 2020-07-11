using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Structure.Entities;

namespace Task.Structure.ViewModels
{
    public static class ClientExtentions
    {
        public static ClientViewModel ToViewModel(this Client Model)
        {
            return new ClientViewModel() {
                ID = Model.ID,
                Name = Model.Name ,
                Email = Model.Email,
                Phone = Model.Phone,
                GroupID =  Model.GroupID,
                Group = Model.Group.ToViewModel()
            };
        }
        public static ClientEditViewModel ToEditableViewModel(this Client Model)
        {
            return new ClientEditViewModel() {
                ID = Model.ID,
                Name = Model.Name,
                Email = Model.Email,
                Phone = Model.Phone,
                GroupID = Model.GroupID,
            };
        }
        public static Client ToModel (this ClientEditViewModel EditModel)
        {
            return new Client() {
                ID = EditModel.ID,
                Name = EditModel.Name,
                Email = EditModel.Email,
                Phone = EditModel.Phone,
                GroupID = EditModel.GroupID
            };
        }
    }
}
