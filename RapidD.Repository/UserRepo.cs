using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapidD.DataAccess;
using RapidD.Repository.Interface;

namespace RapidD.Repository
{
    public class UserRepo : IUser
    {
        private RapidDEntities _context;

        public UserRepo(RapidDEntities context)
        {
            this._context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public User GetUser(int userId)
        {
            return _context.Users.Find(userId);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
        }

        public User IsValidUser(string email, string password)
        {
            var data = from u in _context.Users
                       where u.Email == email && u.Password == password
                       select u;
            return data.Count() > 0 ? data.FirstOrDefault() : null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
