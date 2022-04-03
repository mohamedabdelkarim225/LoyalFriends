using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.CorporateStatusHistory
{
    public class CorporateStatusHistory
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.CorporateStatusHistory> CorporateStatusHistoryRepository;

        public CorporateStatusHistory()
        {
            CorporateStatusHistoryRepository = unitOfWork.Repository<Core.Data.CorporateStatusHistory>();
        }
        #region CorporateStatusHistory 
        
        public IQueryable<Core.Data.CorporateStatusHistory > SearchFor(Expression<Func<Core.Data.CorporateStatusHistory , bool>> predicate)
        {
            return CorporateStatusHistoryRepository.SearchFor(predicate);
        }


        public List<Core.Data.CorporateStatusHistory > GetCorporateStatusHistoryBySQLStatment(string query, object[] parameters)
        {
            return CorporateStatusHistoryRepository.ExecuteSQLQuery(query, parameters);
        }


        #endregion
    }
}
