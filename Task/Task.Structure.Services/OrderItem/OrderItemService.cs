
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
    public class OrderItemService
    {
        UnitOfWork unitOfWork;
        Generic<OrderItem> OrderItemRepo;
        public OrderItemService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            OrderItemRepo = unitOfWork.OrderItemRepo;
        }
        public OrderItemEditViewModel Add (OrderItemEditViewModel OrderItemEditViewModel)
        {
            OrderItem OrderItem = OrderItemRepo.Add(OrderItemEditViewModel.ToModel());
            unitOfWork.commit();
            return OrderItem.ToEditableViewModel();
        }
        public OrderItemEditViewModel Update(OrderItemEditViewModel OrderItemEditViewModel)
        {
            OrderItem OrderItem = OrderItemRepo.Update(OrderItemEditViewModel.ToModel());
            unitOfWork.commit();
            return OrderItem.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            OrderItemRepo.Remove(OrderItemRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<OrderItemViewModel> Get(int id)
        {
            return OrderItemRepo.Get(i => i.ID == id).ToList().Select(i=>i.ToViewModel());
        }
        public IEnumerable<OrderItemViewModel> GetAll(int id)
        {      
            return OrderItemRepo.GetAll().ToList().Select(i=>i.ToViewModel());
        }
        public OrderItemViewModel GetByID(int id)
        {
            return OrderItemRepo.GetByID(id)?.ToViewModel();
        }

    }
}
