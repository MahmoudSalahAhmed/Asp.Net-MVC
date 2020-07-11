using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Structure.Entities;

namespace Task.Structure.Repositories
{
    public class UnitOfWork
    {
        private EntitiesContexts context;
        public Generic<Admin> AdminRepo { get; set; }
        public Generic<Client> ClientRepo { get; set; }
        public Generic<Group> GroupRepo { get; set; }
        public Generic<Item> ItemRepo { get; set; }
        public Generic<Order> OrderRepo { get; set; }
        public Generic<OrderItem> OrderItemRepo { get; set; }
        public UnitOfWork
        (
            EntitiesContexts _context,
            Generic<Admin> _AdminRepo,
            Generic<Client> _ClientRepo,
            Generic<Group> _GroupRepo,
            Generic<Item> _ItemRepo,
            Generic<Order> _OrderRepo,
            Generic<OrderItem> _OrderItemRepo
        )
        {
            context = _context;
            AdminRepo = _AdminRepo;
            AdminRepo.Context = context;
            ClientRepo = _ClientRepo;
            ClientRepo.Context = context;
            GroupRepo = _GroupRepo;
            GroupRepo.Context = context;
            ItemRepo = _ItemRepo;
            ItemRepo.Context = context;
            OrderRepo = _OrderRepo;
            OrderRepo.Context = context;
            OrderItemRepo = _OrderItemRepo;
            OrderItemRepo.Context = context;
        }
        public int commit()
        {
            return context.SaveChanges();
        }
    }
}
