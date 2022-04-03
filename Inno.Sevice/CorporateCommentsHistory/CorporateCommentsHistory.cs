using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.CorporateCommentsHistory
{
    public class CorporateCommentsHistory
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.CorporateCommentsHistory> CorporateCommentsHistoryRepository;

        public CorporateCommentsHistory()
        {
            CorporateCommentsHistoryRepository = unitOfWork.Repository<Core.Data.CorporateCommentsHistory>();
        }
        #region CorporateCommentsHistory
        
        public IQueryable<Core.Data.CorporateCommentsHistory> SearchFor(Expression<Func<Core.Data.CorporateCommentsHistory, bool>> predicate)
        {
            return CorporateCommentsHistoryRepository.SearchFor(predicate);
        }


        public List<Core.Data.CorporateCommentsHistory> GetCorporateCommentsHistoryBySQLStatment(string query, object[] parameters)
        {
            return CorporateCommentsHistoryRepository.ExecuteSQLQuery(query, parameters);
        }


        #endregion
    }
}
