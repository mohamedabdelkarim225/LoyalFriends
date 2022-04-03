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
