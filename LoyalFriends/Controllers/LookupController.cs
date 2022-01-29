using Inno.Core.Data;
using Inno.Utility;
using LoyalFriends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoyalFriends.Controllers
{
    public class LookupController : ApiBaseController
    {
        
        [HttpGet]
        [ResponseType(typeof(LookupResponseObj))]
        public HttpResponseMessage GetServiceQuota(HttpRequestMessage request, int ServiceProviderID)
        {
            var Query = "select * from [LK].[Lookups] as l where l.LookupCategoryID=" + (int)LookupCategories.ServiceQuota + " and l.ParentID=" + ServiceProviderID;
            return Lookups(request, Query);
        }

        [HttpGet]
        [ResponseType(typeof(LookupResponseObj))]
        public HttpResponseMessage GetOffer(HttpRequestMessage request, int ServiceQuotaID)
        {
            var Query = "select * from [LK].[Lookups] as l where l.LookupCategoryID=" + (int)LookupCategories.Offer + " and l.ParentID=" + ServiceQuotaID;
            return Lookups(request, Query);
        }

        [HttpGet]
        [ResponseType(typeof(LookupResponseObj))]
        public HttpResponseMessage GetCustomerLookups(HttpRequestMessage request)
        {
            var Query = "select * from [LK].[Lookups] as l where l.LookupCategoryID=" + (int)LookupCategories.Governorate +  " or l.LookupCategoryID=" + (int)LookupCategories.ServiceProvider + " or l.LookupCategoryID=" + (int)LookupCategories.CustomerStatus + " or l.LookupCategoryID=" + (int)LookupCategories.RouterType + " or l.LookupCategoryID=" + (int)LookupCategories.RouterDeliveryMethod + " or l.LookupCategoryID=" + (int)LookupCategories.CustomerType + " or l.LookupCategoryID=" + (int)LookupCategories.RequestType;
            return Lookups(request, Query);
        }

        [HttpGet]
        [ResponseType(typeof(LookupResponseObj))]
        public HttpResponseMessage GetCorporateLookups(HttpRequestMessage request)
        {
            var Query = "select * from [LK].[Lookups] as l where l.LookupCategoryID=" + (int)LookupCategories.AccountType + " or l.LookupCategoryID=" + (int)LookupCategories.CustomerStatus+ " or l.LookupCategoryID="+ (int)LookupCategories.RequestType;
            return Lookups(request, Query);
        }
        public HttpResponseMessage Lookups(HttpRequestMessage request, string Query)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new LookupResponseObj();
            try
            {
                var Lookups = LookupService.GetLookupBySQLStatment(Query, new object[] { });
                var Governorates = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.Governorate).ToList();
                var Offers = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.Offer).ToList();
                var ServiceProviderLst = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.ServiceProvider).ToList();
                var ServiceQuotaLst = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.ServiceQuota).ToList();
                var CustomerStatusLst = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.CustomerStatus).ToList();
                var RequestTypeLst= Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.RequestType).ToList();
                var RouterTypeLst = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.RouterType).ToList();
                var RouterDeliveryMethodLst = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.RouterDeliveryMethod).ToList();
                var CustomerTypeLst = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.CustomerType).ToList();
                var AccountTypeLst = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.AccountType).ToList();
                LookupsList list = new LookupsList
                {
                    Governorate = MappingLookupList(Governorates),
                    Offer = MappingLookupList(Offers),
                    ServiceProvider = MappingLookupList(ServiceProviderLst),
                    ServiceQuota = MappingLookupList(ServiceQuotaLst),
                    CustomerStatus = MappingLookupList(CustomerStatusLst),
                    RequestType = MappingLookupList(RequestTypeLst),
                    RouterType = MappingLookupList(RouterTypeLst),
                    RouterDeliveryMethod = MappingLookupList(RouterDeliveryMethodLst),
                    CustomerType = MappingLookupList(CustomerTypeLst),
                    AccountType= MappingLookupList(AccountTypeLst)
                };

                resposeObj.status = "successfully";
                resposeObj.Lookups = list;
                ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);

            }
            catch (Exception ex)
            {
                resposeObj.status = "Failure";
                resposeObj.error = ex.Message;
                ResponseMessage = request.CreateResponse(HttpStatusCode.BadRequest, resposeObj);
            }

            return ResponseMessage;

        }

        public List<LookupObj> MappingLookupList(List<Lookup> Lookups)
        {
            var list = new List<LookupObj>();
            if (Lookups != null && Lookups.Count > 0)
            {

                Lookups.ForEach(a =>
                {
                    var l = new LookupObj
                    {
                        ID = a.ID,
                        Name = a.Name
                    };
                    list.Add(l);
                });
            }
            return list;
        }
    }
}
