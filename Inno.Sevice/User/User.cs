using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.User
{
    public class User
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.User> UserRepository;

        public User()
        {
            UserRepository = unitOfWork.Repository<Core.Data.User>();
        }
        #region User
        public Core.Data.User GetUserById(int user_id)
        {
            return UserRepository.Table.Where(c => c.ID == user_id).FirstOrDefault();

        }
        public string GetUserName(int? id)
        {

            return (id != null ? UserRepository.Table.Where(c => c.ID == id).FirstOrDefault().Name : "");
        }

        public bool IsFound(string UserName)
        {
            var Check = UserRepository.Table.Where(a => a.UserName == UserName).FirstOrDefault();
            return (Check != null ? true : false);
        }
        public Core.Data.User CheckUser(string UserName, string Password)
        {
            return UserRepository.Table.Where(c => c.UserName == UserName && c.Password == Password && c.IsActive == true).FirstOrDefault();
        }
        public Core.Data.User AddUser(Core.Data.User model)
        {
            UserRepository.Insert(model);
            return model;
        }
        public Core.Data.User EditUser(Core.Data.User model)
        {

            var NewUser = UserRepository.GetById(model.ID);
            foreach (var item in model.GetType().GetProperties())
            {
                foreach (var item2 in NewUser.GetType().GetProperties())
                {
                    if (item.GetValue(model) != null)
                    {
                        if (item2.Name == item.Name)
                        {
                            item2.SetValue(NewUser, item.GetValue(model));
                        }
                    }
                }
            }
            //NewUser.User_Password = model.User_Password;
            //NewUser.User_Name = model.User_Name;
            UserRepository.Update(NewUser);
            return NewUser;
        }
        public IQueryable<Core.Data.User> GetAllUser()
        {
            var users = UserRepository.Table.OrderByDescending(c => c.ID).AsQueryable();
            return users;
        }
        public IQueryable<Core.Data.User> SearchFor(Expression<Func<Core.Data.User, bool>> predicate)
        {
            return UserRepository.SearchFor(predicate);
        }
        #endregion
        public List<Core.Data.User> GetUserBySQLStatment(string query, object[] parameters)
        {
            return UserRepository.ExecuteSQLQuery(query, parameters);
        }

    }

}
