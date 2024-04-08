using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Interfaces
{
    public interface IUserRepository
    {
        bool EmailExist(string email);
        List<User> GetAll();    
        User GetById(string eMail, string password);
        User Update(string eMail, User user);
        User Add(User user);
        bool UpdatePassword(string eMail, string password);

    }
}

