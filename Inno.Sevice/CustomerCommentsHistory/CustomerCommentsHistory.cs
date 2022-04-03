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
