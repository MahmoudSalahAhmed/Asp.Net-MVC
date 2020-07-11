using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Structure.Entities;

namespace Task.Structure.ViewModels
{
    public static class GroupExtentions
    {
        public static GroupViewModel ToViewModel(this Group Model)
        {
            return new GroupViewModel()
            {
                ID = Model.ID,
                Name = Model.Name
            };
        }
        public static Group ToModel(this GroupEditViewModel EditModel)
        {
            return new Group()
            {
                ID = EditModel.ID,
                Name = EditModel.Name
            };
        }
        public static GroupEditViewModel ToEditableViewModel(this Group Model)
        {
            return new GroupEditViewModel()
            {
                ID = Model.ID,
                Name = Model.Name
            };
        }
    }
}
