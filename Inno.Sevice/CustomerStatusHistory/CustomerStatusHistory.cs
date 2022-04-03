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
