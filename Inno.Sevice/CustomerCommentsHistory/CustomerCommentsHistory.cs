using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.CustomerCommentsHistory
{
    public class CustomerCommentsHistory
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.CustomerCommentsHistory> CustomerCommentsHistoryRepository;

        public CustomerCommentsHistory()
        {
            CustomerCommentsHistoryRepository = unitOfWork.Repository<Core.Data.CustomerCommentsHistory>();
        }
        #region CustomerCommentsHistory
        public Core.Data.CustomerCommentsHistory GetCustomerCommentsHistoryById(int id)
        {
            var CustomerCommentsHistory = CustomerCommentsHistoryRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return CustomerCommentsHistory;
        }

        public Core.Data.CustomerCommentsHistory GetLastCustomerCommentsHistoryByCustomerId(int id)
        {
            var CustomerCommentsHistoryList = CustomerCommentsHistoryRepository.Table.Where(c => c.CustomerID == id).ToList();
            if (CustomerCommentsHistoryList.Count > 0)
            {
                return CustomerCommentsHistoryList.LastOrDefault();
            }
            return null;
        }

        public bool AddCustomerCommentsHistory(Core.Data.CustomerCommentsHistory model)
        {
            try
            {
                CustomerCommentsHistoryRepository.Insert(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Core.Data.CustomerCommentsHistory EditCustomerCommentsHistory(Core.Data.CustomerCommentsHistory model)
        {

            var NewItem = CustomerCommentsHistoryRepository.GetById(model.ID);
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

            CustomerCommentsHistoryRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteCustomerCommentsHistory(int CustomerCommentsHistoryId)
        {
            try
            {
                var CustomerCommentsHistory = CustomerCommentsHistoryRepository.GetById(CustomerCommentsHistoryId);
                CustomerCommentsHistoryRepository.Delete(CustomerCommentsHistory);
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.CustomerCommentsHistory> GetAllCustomerCommentsHistorys()
        {
            var CustomerCommentsHistorys = CustomerCommentsHistoryRepository.Table.AsQueryable();
            return CustomerCommentsHistorys;
        }

        public IQueryable<Core.Data.CustomerCommentsHistory> SearchFor(Expression<Func<Core.Data.CustomerCommentsHistory, bool>> predicate)
        {
            return CustomerCommentsHistoryRepository.SearchFor(predicate);
        }


        public List<Core.Data.CustomerCommentsHistory> GetCustomerCommentsHistoryBySQLStatment(string query, object[] parameters)
        {
            return CustomerCommentsHistoryRepository.ExecuteSQLQuery(query, parameters);
        }


        #endregion
    }
}
