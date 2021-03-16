using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapidD.DataAccess;

namespace RapidD.Repository.Interface
{
    public interface IUser
    {
        void CreateUser(User user);
        User GetUser(int userId);
        void UpdateUser(User user);
        User IsValidUser(string email, string password);
        void Save();
    }
}
