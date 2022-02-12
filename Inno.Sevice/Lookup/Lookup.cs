using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.Lookup
{
    public class Lookup
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.Lookup> LookupRepository;

        public Lookup()
        {
            LookupRepository = unitOfWork.Repository<Core.Data.Lookup>();
        }
        #region Lookup
        public Core.Data.Lookup GetLookupById(int id)
        {
            var Lookup = LookupRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return Lookup;
        }

        public bool AddLookup(Core.Data.Lookup model)
        {
            try
            {
                LookupRepository.Insert(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Core.Data.Lookup EditLookup(Core.Data.Lookup model)
        {

            var NewItem = LookupRepository.GetById(model.ID);
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

            LookupRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteLookup(int LookupId)
        {
            try
            {
                var Lookup = LookupRepository.GetById(LookupId);
                LookupRepository.Delete(Lookup);
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.Lookup> GetAllLookups()
        {
            var Lookups = LookupRepository.Table.AsQueryable();
            return Lookups;
        }

        public string GetLookupName(int? id)
        {

            return (id != null ? LookupRepository.Table.Where(c => c.ID == id).FirstOrDefault().Name : "");
        }
        public IQueryable<Core.Data.Lookup> GetLookupByCategoryId(int CategoryId)
        {
            var Items = LookupRepository.Table.Where(c => c.LookupCategoryID == CategoryId).AsQueryable();
            return Items;
        }
        public IQueryable<Core.Data.Lookup> SearchFor(Expression<Func<Core.Data.Lookup, bool>> predicate)
        {
            return LookupRepository.SearchFor(predicate);
        }


        public List <Core.Data.Lookup> GetLookupBySQLStatment(string query, object[] parameters)
        {
           return LookupRepository.ExecuteSQLQuery(query, parameters);
        }

        public int GetLookupCount()
        {
            return LookupRepository.Table.Count();
        }
        #endregion
    }
}
