using Dal.Models;
using Dto.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Interfaces
{
    public interface IUserService
    {
        bool EmailExist(string email);
        List<UserDto> GetAll();
        UserDto GetById(string eMail, string password);
        UserDto Update(string eMail, UserDto user);
        UserDto Add(UserDto user);
        bool UpdatePassword(string eMail, string password);
    }
}
