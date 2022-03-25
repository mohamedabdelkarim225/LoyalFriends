using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.CustomerStatusHistory
{
    public class CustomerStatusHistory
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.CustomerStatusHistory> CustomerStatusHistoryRepository;

        public CustomerStatusHistory()
        {
            CustomerStatusHistoryRepository = unitOfWork.Repository<Core.Data.CustomerStatusHistory>();
        }
        #region CustomerStatusHistory
        public Core.Data.CustomerStatusHistory GetCustomerStatusHistoryById(int id)
        {
            var CustomerStatusHistory = CustomerStatusHistoryRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return CustomerStatusHistory;
        }

        public Core.Data.CustomerStatusHistory GetLastCustomerStatusHistoryByCustomerId(int id)
        {
            var CustomerStatusHistoryList = CustomerStatusHistoryRepository.Table.Where(c => c.CustomerID == id).ToList();
            if (CustomerStatusHistoryList.Count > 0)
            {
                return CustomerStatusHistoryList.LastOrDefault();
            }
            return null;
        }

        public bool AddCustomerStatusHistory(Core.Data.CustomerStatusHistory model)
        {
            try
            {
                CustomerStatusHistoryRepository.Insert(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Core.Data.CustomerStatusHistory EditCustomerStatusHistory(Core.Data.CustomerStatusHistory model)
        {

            var NewItem = CustomerStatusHistoryRepository.GetById(model.ID);
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

            CustomerStatusHistoryRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteCustomerStatusHistory(int CustomerStatusHistoryId)
        {
            try
            {
                var CustomerStatusHistory = CustomerStatusHistoryRepository.GetById(CustomerStatusHistoryId);
                CustomerStatusHistoryRepository.Delete(CustomerStatusHistory);
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.CustomerStatusHistory> GetAllCustomerStatusHistorys()
        {
            var CustomerStatusHistorys = CustomerStatusHistoryRepository.Table.AsQueryable();
            return CustomerStatusHistorys;
        }

        public IQueryable<Core.Data.CustomerStatusHistory> SearchFor(Expression<Func<Core.Data.CustomerStatusHistory, bool>> predicate)
        {
            return CustomerStatusHistoryRepository.SearchFor(predicate);
        }


        public List<Core.Data.CustomerStatusHistory> GetCustomerStatusHistoryBySQLStatment(string query, object[] parameters)
        {
            return CustomerStatusHistoryRepository.ExecuteSQLQuery(query, parameters);
        }


        #endregion
    }
}
