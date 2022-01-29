using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.Customer
{
    public class Customer
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.Customer> CustomerRepository;

        public Customer()
        {
            CustomerRepository = unitOfWork.Repository<Core.Data.Customer>();
        }
        #region Customer
        public Core.Data.Customer GetCustomerById(int id)
        {
            var Customer = CustomerRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return Customer;
        }

        public Core.Data.Customer AddCustomer(Core.Data.Customer model)
        {
            CustomerRepository.Insert(model);
            return model;
        }
        public Core.Data.Customer EditCustomer(Core.Data.Customer model)
        {

            var NewItem = CustomerRepository.GetById(model.ID);
            foreach (var item in model.GetType().GetProperties())
            {
                foreach (var item2 in NewItem.GetType().GetProperties())
                {
                    if (item.GetValue(model) != null)
                    {
                        if (item2.Name == item.Name)
                        {
                            item2.SetValue(NewItem, item.GetValue(model));
                        }
                    }
                }
            }

            CustomerRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteCustomer(int CustomerId)
        {
            try
            {
                var Customer = CustomerRepository.GetById(CustomerId);
                CustomerRepository.Delete(Customer);
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.Customer> GetAllCustomers()
        {
            var Customers = CustomerRepository.Table.AsQueryable();
            return Customers;
        }

        public IQueryable<Core.Data.Customer> SearchFor(Expression<Func<Core.Data.Customer, bool>> predicate)
        {
            return CustomerRepository.SearchFor(predicate);
        }


        public List<Core.Data.Customer> GetCustomerBySQLStatment(string query, object[] parameters)
        {
            return CustomerRepository.ExecuteSQLQuery(query, parameters);
        }

        public int GetCustomerCount(Expression<Func<Core.Data.Customer, bool>> predicate)
        {
            return CustomerRepository.Table.Count(predicate);
        }

        #endregion
    }
}
