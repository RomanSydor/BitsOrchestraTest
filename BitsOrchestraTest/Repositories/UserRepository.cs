using BitsOrchestraTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitsOrchestraTest.Repositories
{
    public interface IUserRepository 
    {
        IEnumerable<User> GetUsers(Func<User, bool> funcGetUsers);
        User GetUserByProp(Func<User, bool> funcGetUserByProp);
        void AddUserToDb();
        void DeleteUser(User user);
        void EditUser(User user, Action<User> editAction);
    }

    public class UserRepository : IUserRepository
    {
        private DataContext _db;

        public UserRepository(DataContext dataContext)
        {
            _db = dataContext;
        }

        public IEnumerable<User> GetUsers(Func<User, bool> funcGetUsers)
        {
            return _db.Users.Where(user => funcGetUsers(user));
        }

        public User GetUserByProp(Func<User, bool> funcGetUserByProp)
        {
            return GetUsers(funcGetUserByProp).FirstOrDefault();
        }

        public void DeleteUser(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public void EditUser(User user, Action<User> editAction)
        {
            var u = GetUserByProp(x => x.Id == user.Id);
            
            editAction(u);
            _db.SaveChanges();
        }

        public void AddUserToDb()
        {
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            foreach (var item in UsersList.Users)
            {
                _db.Users.Add(item);
            }
            _db.SaveChanges();
        }
    }
}
