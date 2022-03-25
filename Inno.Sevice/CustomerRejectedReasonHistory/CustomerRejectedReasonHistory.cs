using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.CustomerRejectedReasonHistory
{
    public class CustomerRejectedReasonHistory
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.CustomerRejectedReasonHistory> CustomerRejectedReasonHistoryRepository;

        public CustomerRejectedReasonHistory()
        {
            CustomerRejectedReasonHistoryRepository = unitOfWork.Repository<Core.Data.CustomerRejectedReasonHistory>();
        }
        #region CustomerRejectedReasonHistory
        public Core.Data.CustomerRejectedReasonHistory GetCustomerRejectedReasonHistoryById(int id)
        {
            var CustomerRejectedReasonHistory = CustomerRejectedReasonHistoryRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return CustomerRejectedReasonHistory;
        }

        public Core.Data.CustomerRejectedReasonHistory GetLastCustomerRejectedReasonHistoryByCustomerId(int id)
        {
            var CustomerRejectedReasonHistoryList = CustomerRejectedReasonHistoryRepository.Table.Where(c => c.CustomerID == id).ToList();
            if (CustomerRejectedReasonHistoryList.Count > 0)
            {
                return CustomerRejectedReasonHistoryList.LastOrDefault();
            }
            return null;
        }

        public bool AddCustomerRejectedReasonHistory(Core.Data.CustomerRejectedReasonHistory model)
        {
            try
            {
                CustomerRejectedReasonHistoryRepository.Insert(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Core.Data.CustomerRejectedReasonHistory EditCustomerRejectedReasonHistory(Core.Data.CustomerRejectedReasonHistory model)
        {

            var NewItem = CustomerRejectedReasonHistoryRepository.GetById(model.ID);
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

            CustomerRejectedReasonHistoryRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteCustomerRejectedReasonHistory(int CustomerRejectedReasonHistoryId)
        {
            try
            {
                var CustomerRejectedReasonHistory = CustomerRejectedReasonHistoryRepository.GetById(CustomerRejectedReasonHistoryId);
                CustomerRejectedReasonHistoryRepository.Delete(CustomerRejectedReasonHistory);
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.CustomerRejectedReasonHistory> GetAllCustomerRejectedReasonHistorys()
        {
            var CustomerRejectedReasonHistorys = CustomerRejectedReasonHistoryRepository.Table.AsQueryable();
            return CustomerRejectedReasonHistorys;
        }

        public IQueryable<Core.Data.CustomerRejectedReasonHistory> SearchFor(Expression<Func<Core.Data.CustomerRejectedReasonHistory, bool>> predicate)
        {
            return CustomerRejectedReasonHistoryRepository.SearchFor(predicate);
        }


        public List<Core.Data.CustomerRejectedReasonHistory> GetCustomerRejectedReasonHistoryBySQLStatment(string query, object[] parameters)
        {
            return CustomerRejectedReasonHistoryRepository.ExecuteSQLQuery(query, parameters);
        }


        #endregion
    }
}
