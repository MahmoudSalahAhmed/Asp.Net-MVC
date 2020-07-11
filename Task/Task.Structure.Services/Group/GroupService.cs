using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Structure.Entities;
using Task.Structure.Repositories;
using Task.Structure.ViewModels;

namespace Task.Structure.Services
{
    public class GroupService
    {
        UnitOfWork unitOfWork;
        Generic<Group> GroupRepo;
        public GroupService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            GroupRepo = unitOfWork.GroupRepo;
        }
        public GroupEditViewModel Add(GroupEditViewModel GroupEditViewModel)
        {
            Group Group = GroupRepo.Add(GroupEditViewModel.ToModel());
            unitOfWork.commit();
            return Group.ToEditableViewModel();
        }
        public GroupEditViewModel Update(GroupEditViewModel GroupEditViewModel)
        {
            Group Group = GroupRepo.Update(GroupEditViewModel.ToModel());
            unitOfWork.commit();
            return Group.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            GroupRepo.Remove(GroupRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<GroupViewModel> Get(int id)
        {
            return GroupRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<GroupViewModel> GetAll()
        {
            return GroupRepo.GetAll().Select(i => i.ToViewModel()).ToList();
        }
        public GroupViewModel GetByID(int id)
        {
            return GroupRepo.GetByID(id).ToViewModel();
        }
    }
}
