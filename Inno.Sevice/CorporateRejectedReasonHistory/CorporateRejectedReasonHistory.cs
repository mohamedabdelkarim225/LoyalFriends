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
        public Core.Data.CorporateRejectedReasonHistory  GetCorporateRejectedReasonHistoryById(int id)
        {
            var CorporateRejectedReasonHistory  = CorporateRejectedReasonHistoryRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return CorporateRejectedReasonHistory ;
        }

        public Core.Data.CorporateRejectedReasonHistory  GetLastCorporateRejectedReasonHistoryByCorporateId(int id)
        {
            var CorporateRejectedReasonHistoryList = CorporateRejectedReasonHistoryRepository.Table.Where(c => c.CorporateID == id).ToList();
            if (CorporateRejectedReasonHistoryList.Count > 0)
            {
                return CorporateRejectedReasonHistoryList.LastOrDefault();
            }
            return null;
        }

        public bool AddCorporateRejectedReasonHistory (Core.Data.CorporateRejectedReasonHistory  model)
        {
            try
            {
                CorporateRejectedReasonHistoryRepository.Insert(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Core.Data.CorporateRejectedReasonHistory  EditCorporateRejectedReasonHistory (Core.Data.CorporateRejectedReasonHistory  model)
        {

            var NewItem = CorporateRejectedReasonHistoryRepository.GetById(model.ID);
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

            CorporateRejectedReasonHistoryRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteCorporateRejectedReasonHistory (int CorporateRejectedReasonHistoryId)
        {
            try
            {
                var CorporateRejectedReasonHistory  = CorporateRejectedReasonHistoryRepository.GetById(CorporateRejectedReasonHistoryId);
                CorporateRejectedReasonHistoryRepository.Delete(CorporateRejectedReasonHistory );
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.CorporateRejectedReasonHistory > GetAllCorporateRejectedReasonHistorys()
        {
            var CorporateRejectedReasonHistorys = CorporateRejectedReasonHistoryRepository.Table.AsQueryable();
            return CorporateRejectedReasonHistorys;
        }

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
