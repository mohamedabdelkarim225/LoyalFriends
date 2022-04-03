using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.CorporateRejectedReasonHistory
{
    public class CorporateRejectedReasonHistory
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.CorporateRejectedReasonHistory> CorporateRejectedReasonHistoryRepository;

        public CorporateRejectedReasonHistory()
        {
            CorporateRejectedReasonHistoryRepository = unitOfWork.Repository<Core.Data.CorporateRejectedReasonHistory>();
        }
        #region CorporateRejectedReasonHistory 

        public IQueryable<Core.Data.CorporateRejectedReasonHistory > SearchFor(Expression<Func<Core.Data.CorporateRejectedReasonHistory , bool>> predicate)
        {
            return CorporateRejectedReasonHistoryRepository.SearchFor(predicate);
        }


        public List<Core.Data.CorporateRejectedReasonHistory > GetCorporateRejectedReasonHistoryBySQLStatment(string query, object[] parameters)
        {
            return CorporateRejectedReasonHistoryRepository.ExecuteSQLQuery(query, parameters);
        }


        #endregion
    }
}
