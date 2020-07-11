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
    public class StatisticsService
    {
        UnitOfWork unitOfWork;
        Generic<Order> OrderRepo;
        Generic<Item> ItemRepo;
        Generic<Group> GroupRepo;
        Generic<Client> ClientRepo;

        public StatisticsService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            OrderRepo = unitOfWork.OrderRepo;
            ItemRepo = unitOfWork.ItemRepo;
            GroupRepo = unitOfWork.GroupRepo;
            ClientRepo = unitOfWork.ClientRepo;
        }



        public StatisticsViewModel GetStatistics()
        {
            StatisticsViewModel report = new StatisticsViewModel();
            report.Orders = OrderRepo.GetAll().Count();
            report.Items = ItemRepo.GetAll().Count();
            report.Groups = GroupRepo.GetAll().Count();
            report.Clients = ClientRepo.GetAll().Count();
            return report;
        }
    }
}
