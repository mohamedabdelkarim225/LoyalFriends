using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.Corporate
{
    public class Corporate
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.Corporate> CorporateRepository;

        public Corporate()
        {
            CorporateRepository = unitOfWork.Repository<Core.Data.Corporate>();
        }
        #region Corporate
        public Core.Data.Corporate GetCorporateById(int id)
        {
            var Corporate = CorporateRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return Corporate;
        }

        public Core.Data.Corporate AddCorporate(Core.Data.Corporate model)
        {
            CorporateRepository.Insert(model);
            return model;
        }
        public Core.Data.Corporate EditCorporate(Core.Data.Corporate model)
        {

            var NewItem = CorporateRepository.GetById(model.ID);
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

            CorporateRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteCorporate(int CorporateId)
        {
            try
            {
                var Corporate = CorporateRepository.GetById(CorporateId);
                CorporateRepository.Delete(Corporate);
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.Corporate> GetAllCorporates()
        {
            var Corporates = CorporateRepository.Table.AsQueryable();
            return Corporates;
        }

        public IQueryable<Core.Data.Corporate> SearchFor(Expression<Func<Core.Data.Corporate, bool>> predicate)
        {
            return CorporateRepository.SearchFor(predicate);
        }


        public List<Core.Data.Corporate> GetCorporateBySQLStatment(string query, object[] parameters)
        {
            return CorporateRepository.ExecuteSQLQuery(query, parameters);
        }

        public int GetCorporateCount(Expression<Func<Core.Data.Corporate, bool>> predicate)
        {
            return CorporateRepository.Table.Count(predicate);
        }
        public int GetCorporateCount()
        {
            return CorporateRepository.Table.Count();
        }
        #endregion
    }
}
