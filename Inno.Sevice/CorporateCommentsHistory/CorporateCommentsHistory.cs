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
        public Core.Data.CorporateCommentsHistory GetCorporateCommentsHistoryById(int id)
        {
            var CorporateCommentsHistory = CorporateCommentsHistoryRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return CorporateCommentsHistory;
        }

        public Core.Data.CorporateCommentsHistory GetLastCorporateCommentsHistoryByCorporateId(int id)
        {
            var CorporateCommentsHistory = CorporateCommentsHistoryRepository.Table.Where(c => c.CorporateID == id).ToList().LastOrDefault();
            return CorporateCommentsHistory;
        }

        public bool AddCorporateCommentsHistory(Core.Data.CorporateCommentsHistory model)
        {
            try
            {
                CorporateCommentsHistoryRepository.Insert(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Core.Data.CorporateCommentsHistory EditCorporateCommentsHistory(Core.Data.CorporateCommentsHistory model)
        {

            var NewItem = CorporateCommentsHistoryRepository.GetById(model.ID);
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

            CorporateCommentsHistoryRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteCorporateCommentsHistory(int CorporateCommentsHistoryId)
        {
            try
            {
                var CorporateCommentsHistory = CorporateCommentsHistoryRepository.GetById(CorporateCommentsHistoryId);
                CorporateCommentsHistoryRepository.Delete(CorporateCommentsHistory);
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.CorporateCommentsHistory> GetAllCorporateCommentsHistorys()
        {
            var CorporateCommentsHistorys = CorporateCommentsHistoryRepository.Table.AsQueryable();
            return CorporateCommentsHistorys;
        }
        
        public IQueryable<Core.Data.CorporateCommentsHistory> SearchFor(Expression<Func<Core.Data.CorporateCommentsHistory, bool>> predicate)
        {
            return CorporateCommentsHistoryRepository.SearchFor(predicate);
        }


        public List <Core.Data.CorporateCommentsHistory> GetCorporateCommentsHistoryBySQLStatment(string query, object[] parameters)
        {
           return CorporateCommentsHistoryRepository.ExecuteSQLQuery(query, parameters);
        }


        #endregion
    }
}
