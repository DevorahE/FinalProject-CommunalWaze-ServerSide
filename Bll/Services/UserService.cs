using AutoMapper;
using Bll.Interfaces;
using Dal.Interfaces;
using Dal.Models;
using Dto.DTOs;

namespace Bll.Services
{
    public class UserService : IUserService
    {
        IUserRepository repository;
        IMapper iMapper;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyProfile>();
            });
            iMapper = config.CreateMapper();
        }
        public UserDto Add(UserDto user)
        {
            User item = repository.Add(iMapper.Map<UserDto, User>(user));
            return iMapper.Map<User, UserDto>(item);
        }

        public bool EmailExist(string email)
        {
            return repository.EmailExist(email);
        }

        public List<UserDto> GetAll()
        {
            List<User> users = repository.GetAll();
            return iMapper.Map<List<User>, List<UserDto>>(users);
        }

        public UserDto GetById(string eMail, string password)
        {
            User user = repository.GetById(eMail, password);
            return iMapper.Map<User,UserDto>(user); 
        }

        public UserDto Update(String eMail, UserDto user)
        {
            User item = repository.Update(eMail, iMapper.Map<UserDto, User>(user));
            return iMapper.Map<User, UserDto>(item);

        }

        public bool UpdatePassword(string eMail, string password)
        {
            bool item = repository.UpdatePassword(eMail, password);
            return item;
        }
    }
}
