using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RapidD.Data;
using RapidD.DataAccess;
using RapidD.Repository;
using RapidD.Repository.Interface;

namespace RapidD.BusinessLogic
{
    public class UserManagement
    {
        private IUser _userRepo;

        public UserManagement()
        {
            this._userRepo = new UserRepo(new RapidDEntities());
        }

        public UserManagement(IUser user)
        {
            this._userRepo = user;
        }

        public int CreateUser(UserModel model)
        {
            User user = new User();
            
            user.Name = model.FullName;
            user.Email = model.Email;
            user.Mobile = model.Mobile;           
            user.Password = model.Password;           

            _userRepo.CreateUser(user);
            try
            {
                _userRepo.Save();
            }
            catch
            {
                throw;
            }
            return user.UserId;
        }

        public UserModel IsValidUser(string email, string password)
        {
            UserModel model = new UserModel();
            User user = _userRepo.IsValidUser(email, password);
            if(user != null)
            {
                model.FullName = user.Name;
                model.Email = user.Email;
                model.UserId = user.UserId;
            }
            return model;
        }

        public int UpdateUser(UserModel model)
        {
            User user = _userRepo.GetUser(model.UserId);

            user.Name = model.FullName;
            user.Password = model.Password;
            user.Mobile = model.Mobile;           

            _userRepo.UpdateUser(user);
            try
            {
                _userRepo.Save();
            }
            catch
            {
                throw;
            }
            return model.UserId;
        }

        public UserModel GetUser(int userId)
        {
            User user = _userRepo.GetUser(userId);
            UserModel model = GetUser(user);
            return model;
        }

        private UserModel GetUser(User user)
        {
            UserModel model = new UserModel();
            model.Email = user.Email;
            model.Mobile = user.Mobile;           
            model.FullName = user.Name;
            model.Password = user.Password;
            model.UserId = user.UserId;
            return model;
        }

        public void DeleteUser(int userId)
        {
            User user = _userRepo.GetUser(userId);
           
            try
            {
                _userRepo.Save();
            }
            catch
            {
                throw;
            }
        }
    }
}
