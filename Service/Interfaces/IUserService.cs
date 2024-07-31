using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<Users> GetAllUsers();
        void CreateUser(Users user);
        Users GetUserByEmailAndPassword(string emailOrUsername, string password);
        bool IsUsernameExist(string username);
        bool IsEmailExist(string email);
    }
}
