using Inno.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Inno.Service.LookupCategory
{
    public class LookupCategory
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected Repository<Core.Data.LookupCategory> LookupCategoryRepository;

        public LookupCategory()
        {
            LookupCategoryRepository = unitOfWork.Repository<Core.Data.LookupCategory>();
        }
        #region LookupCategory
        public Core.Data.LookupCategory GetLookupCategoryById(int id)
        {
            var LookupCategory = LookupCategoryRepository.Table.Where(c => c.ID == id).FirstOrDefault();
            return LookupCategory;
        }

        public bool AddLookupCategory(Core.Data.LookupCategory model)
        {
            try
            {
                LookupCategoryRepository.Insert(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Core.Data.LookupCategory EditLookupCategory(Core.Data.LookupCategory model)
        {

            var NewItem = LookupCategoryRepository.GetById(model.ID);
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

            LookupCategoryRepository.Update(NewItem);
            return NewItem;
        }


        public bool DeleteLookupCategory(int LookupCategoryId)
        {
            try
            {
                var LookupCategory = LookupCategoryRepository.GetById(LookupCategoryId);
                LookupCategoryRepository.Delete(LookupCategory);
            }
            catch (Exception e)
            {
                //delete before Request Lines
                throw new Exception(e.Message);
            }
            return true;
        }

        public IQueryable<Core.Data.LookupCategory> GetAllLookupCategorys()
        {
            var LookupCategorys = LookupCategoryRepository.Table.AsQueryable();
            return LookupCategorys;
        }
       
        public IQueryable<Core.Data.LookupCategory> SearchFor(Expression<Func<Core.Data.LookupCategory, bool>> predicate)
        {
            return LookupCategoryRepository.SearchFor(predicate);
        }


        public List <Core.Data.LookupCategory> GetLookupCategoryBySQLStatment(string query, object[] parameters)
        {
           return LookupCategoryRepository.ExecuteSQLQuery(query, parameters);
        }


        #endregion
    }
}
