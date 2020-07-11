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
    public class AdminService
    {
        UnitOfWork unitOfWork;
        Generic<Admin> AdminRepo;
        public AdminService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            AdminRepo = unitOfWork.AdminRepo;
        }
        public AdminEditViewModel Add(AdminEditViewModel AdminEditViewModel)
        {
            Admin Admin = AdminRepo.Add(AdminEditViewModel.ToModel());
            unitOfWork.commit();
            return Admin.ToEditableViewModel();
        }
        public AdminEditViewModel Update(AdminEditViewModel AdminEditViewModel)
        {
            Admin Admin = AdminRepo.Update(AdminEditViewModel.ToModel());
            unitOfWork.commit();
            return Admin.ToEditableViewModel();
        }
        public void Remove(int id)
        {
            AdminRepo.Remove(AdminRepo.GetByID(id));
            unitOfWork.commit();
        }
        public IEnumerable<AdminViewModel> Get(int id)
        {
            return AdminRepo.Get(i => i.ID == id).ToList().Select(i => i.ToViewModel());
        }
        public IEnumerable<AdminViewModel> GetAll()
        {
            return AdminRepo.GetAll().ToList().Select(i => i.ToViewModel());
        }
        public Admin GetByID(int id)
        {
            return AdminRepo.GetByID(id);
        }
    }
}
