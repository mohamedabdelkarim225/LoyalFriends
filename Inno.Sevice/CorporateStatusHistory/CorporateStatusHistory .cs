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
        public Core.Data.CorporateStatusHistory  GetCorporateStatusHistoryById(int id)
        {
            var CorporateStatusHistory  = CorporateStatusHistoryRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return CorporateStatusHistory ;
        }

        public Core.Data.CorporateStatusHistory  GetLastCorporateStatusHistoryByCorporateId(int id)
        {
            var CorporateStatusHistoryList = CorporateStatusHistoryRepository.Table.Where(c => c.CorporateID == id).ToList();
            if (CorporateStatusHistoryList.Count > 0)
            {
                return CorporateStatusHistoryList.LastOrDefault();
            }
            return null;
        }

        public bool AddCorporateStatusHistory (Core.Data.CorporateStatusHistory  model)
        {
            try
            {
                CorporateStatusHistoryRepository.Insert(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Core.Data.CorporateStatusHistory  EditCorporateStatusHistory (Core.Data.CorporateStatusHistory  model)
        {

            var NewItem = CorporateStatusHistoryRepository.GetById(model.ID);
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

            CorporateStatusHistoryRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteCorporateStatusHistory (int CorporateStatusHistoryId)
        {
            try
            {
                var CorporateStatusHistory  = CorporateStatusHistoryRepository.GetById(CorporateStatusHistoryId);
                CorporateStatusHistoryRepository.Delete(CorporateStatusHistory );
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.CorporateStatusHistory > GetAllCorporateStatusHistorys()
        {
            var CorporateStatusHistorys = CorporateStatusHistoryRepository.Table.AsQueryable();
            return CorporateStatusHistorys;
        }

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
