using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Structure.Entities;

namespace Task.Structure.ViewModels
{
    public static class AdminExtentions
    {
        public static AdminViewModel ToViewModel(this Admin Model)
        {
            return new AdminViewModel() {
                ID = Model.ID,
                UserName = Model.UserName,
                Password = Model.Password,
            };
        }
        public static AdminEditViewModel ToEditableViewModel(this Admin Model)
        {
            return new AdminEditViewModel() {
                ID = Model.ID,
                UserName = Model.UserName,
                Password = Model.Password,
            };
        }
        public static Admin ToModel (this AdminEditViewModel EditModel)
        {
            return new Admin() {
                ID = EditModel.ID,
                UserName = EditModel.UserName,
                Password = EditModel.Password,
            };
        }
    }
}
