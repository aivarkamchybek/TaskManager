using Domain.Entities;
using Domain.Interfaces;
using Repository.Context;
using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _unitOfWork.UserRepo.GetAll();
        }

        public void CreateUser(Users user)
        {
            _unitOfWork.UserRepo.Add(user);
            _unitOfWork.Complete();
        }

        public Users GetUserByEmailAndPassword(string emailOrUsername, string password)
        {
        
            return _unitOfWork.UserRepo.GetAll().FirstOrDefault(u => (u.Email == emailOrUsername || u.Username == emailOrUsername) && u.Password == password);
        }

        public bool IsUsernameExist(string username)
        {
            return _unitOfWork.UserRepo.IsUsernameExists(username);
        }

        public bool IsEmailExist(string email)
        {
            return _unitOfWork.UserRepo.IsEmailExists(email);
        }
    }
}
