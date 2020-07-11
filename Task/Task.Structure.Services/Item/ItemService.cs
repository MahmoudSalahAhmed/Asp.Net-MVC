
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
    public class ItemService
    {
        UnitOfWork unitOfWork;
        Generic<Item> ItemRepo;
        public ItemService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            ItemRepo = unitOfWork.ItemRepo;
        }
        public ItemEditViewModel Add (ItemEditViewModel ItemEditViewModel)
        {
            Item Item = ItemRepo.Add(ItemEditViewModel.ToModel());
            unitOfWork.commit();
            return Item.ToEditableViewModel();
        }
        public ItemEditViewModel Update(ItemEditViewModel ItemEditViewModel)
        {
            Item Item = ItemRepo.Update(ItemEditViewModel.ToModel());
            unitOfWork.commit();
            return Item.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            ItemRepo.Remove(ItemRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<ItemViewModel> Get(int id)
        {
            return ItemRepo.Get(i => i.ID == id).ToList().Select(i=>i.ToViewModel());
        }
        public IEnumerable<ItemViewModel> GetAll()
        {      
            return ItemRepo.GetAll().ToList().Select(i=>i.ToViewModel());
        }
        public ItemViewModel GetByID(int id)
        {
            return ItemRepo.GetByID(id)?.ToViewModel();
        }

    }
}
