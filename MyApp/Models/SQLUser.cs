using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class SQLUser : IUser
    {
        private readonly AppDBContext _appDBContext;

        public SQLUser(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public User Add(User user)
        {
            _appDBContext.Users.Add(user);
            _appDBContext.SaveChanges();
            return user;
        }

        public User Delete(int Id)
        {
            User user = _appDBContext.Users.Find(Id);
            if (user != null)
            {
                _appDBContext.Users.Remove(user);
                _appDBContext.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appDBContext.Users;
        }

        public User GetUser(int Id)
        {
            return _appDBContext.Users.Find(Id);
        }

        public User Update(User userChanges)
        {
            var user = _appDBContext.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDBContext.SaveChanges();
            return userChanges;
        }
    }
}
