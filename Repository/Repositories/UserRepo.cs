using Domain.Entities;
using Domain.Interfaces;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepo : GenericRepo<Users>, IUserRepo
    {
        public UserRepo(QuoteContext context) : base(context)
        {
        }
        public bool IsUsernameExists(string username)
        {
            return _context.Set<Users>().Any(u => u.Username == username);
        }

        public bool IsEmailExists(string email)
        {
            return _context.Set<Users>().Any(u => u.Email == email);
        }

    }
}
