using Dal.Interfaces;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Add(User user)
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return GetById(user.EMail, user.Password);

            }
            catch(Exception ex) 
            {
                _ = ex.Message;
                return null;
            }
        }

        public bool EmailExist(string email)
        {
            using (var db = new CommunalWazeContext())
            {
                bool flag = false;
                List<User> users = db.Users.ToList();
                users.ForEach(x =>
                {
                    if (x.EMail == email)
                        flag = true;
                });
                return flag;

            }
        }

        public List<User> GetAll()
        {
            using (var db = new CommunalWazeContext())
            {
               return db.Users.ToList();
            }
            
        }

        public User GetById(string eMail, string password)
        {
            using (var db = new CommunalWazeContext())
            {  
                return db.Users.FirstOrDefault(s => s.EMail == eMail && s.Password == password);
            }
           
        }

        public User Update(string eMail, User userNew)
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    User user = db.Users.FirstOrDefault(s => s.EMail == eMail);
                    if (user != null) 
                    { 
                    user.FirstName = userNew.FirstName;
                    user.LastName = userNew.LastName;
                    user.EMail = userNew.EMail;
                    user.Password = userNew.Password;
                    }
                    db.SaveChanges();
                }
                return GetById(userNew.EMail, userNew.Password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdatePassword(string eMail, string password)
        {
            try
            {
                using (var db = new CommunalWazeContext())
                {
                    User user = db.Users.FirstOrDefault(s => s.EMail == eMail);
                    user.Password = password;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    }

