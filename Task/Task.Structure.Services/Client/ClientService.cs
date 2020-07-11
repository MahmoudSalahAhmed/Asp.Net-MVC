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
    public class ClientService
    {
        UnitOfWork unitOfWork;
        Generic<Client> ClientRepo;
        public ClientService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            ClientRepo = unitOfWork.ClientRepo;
        }
        public ClientEditViewModel Add(ClientEditViewModel ClientEditViewModel)
        {
            Client Client = ClientRepo.Add(ClientEditViewModel.ToModel());
            unitOfWork.commit();
            return Client.ToEditableViewModel();
        }
        public ClientEditViewModel Update(ClientEditViewModel ClientEditViewModel)
        {
            Client Client = ClientRepo.Update(ClientEditViewModel.ToModel());
            unitOfWork.commit();
            return Client.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            ClientRepo.Remove(ClientRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<ClientViewModel> Get(int id)
        {
            return ClientRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<ClientViewModel> GetAll()
        {
            return ClientRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public Client GetByID(int id)
        {
            return ClientRepo.GetByID(id);
        }
    }
}
