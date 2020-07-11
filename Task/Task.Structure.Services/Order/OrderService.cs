
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
    public class OrderService
    {
        UnitOfWork unitOfWork;
        Generic<Order> OrderRepo;
        public OrderService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            OrderRepo = unitOfWork.OrderRepo;
        }
        public OrderEditViewModel Add (OrderEditViewModel OrderEditViewModel)
        {
            Order Order = OrderRepo.Add(OrderEditViewModel.ToModel());
            unitOfWork.commit();
            return Order.ToEditableViewModel();
        }
        public OrderEditViewModel Update(OrderEditViewModel OrderEditViewModel)
        {
            Order Order = OrderRepo.Update(OrderEditViewModel.ToModel());
            unitOfWork.commit();
            return Order.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            OrderRepo.Remove(OrderRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<OrderViewModel> Get(int id)
        {
            return OrderRepo.Get(i => i.ID == id).ToList().Select(i=>i.ToViewModel());
        }
        public IEnumerable<OrderViewModel> GetAll()
        {      
            return OrderRepo.GetAll().ToList().Select(i=>i.ToViewModel());
        }
        public OrderViewModel GetByID(int id)
        {
            return OrderRepo.GetByID(id)?.ToViewModel();
        }

    }
}
