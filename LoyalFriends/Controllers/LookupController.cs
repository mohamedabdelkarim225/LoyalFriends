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
        [HttpPost]
        [ResponseType(typeof(AddLookupResponseObj))]
        public HttpResponseMessage AddLookup(HttpRequestMessage request, LookupViewmodel Lookupvm, int UserID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddLookupResponseObj();
            try
            {
                if (Lookupvm.LookupCategoryID == (int)LookupCategories.ServiceQuota)
                {
                    var Check = LookupService.SearchFor(a => a.LookupCategoryID == Lookupvm.LookupCategoryID && a.ParentID == Lookupvm.ServiceProviderID && a.Name == Lookupvm.Name).FirstOrDefault();
                    if (Check == null)
                    {
                        var Lookup = new Lookup
                        {
                            Name = Lookupvm.Name,
                            LookupCategoryID = Lookupvm.LookupCategoryID,
                            ParentID = Lookupvm.ServiceProviderID,
                            IsActive=Lookupvm.IsActive,
                            CreatedBy = UserID,
                            CreatedOn = DateTime.Now
                        };
                        LookupService.AddLookup(Lookup);
                        resposeObj.LookupId = Lookup.ID;
                        resposeObj.status = "successfully";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                    else
                    {
                        resposeObj.status = "Failure";
                        resposeObj.error = "LookupName is already exist";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                }
                else if (Lookupvm.LookupCategoryID == (int)LookupCategories.Offer)
                {
                    var Check = LookupService.SearchFor(a => a.LookupCategoryID == Lookupvm.LookupCategoryID && a.ParentID == Lookupvm.ServiceQuotaID && a.Name == Lookupvm.Name).FirstOrDefault();
                    if (Check == null)
                    {
                        var Lookup = new Lookup
                        {
                            Name = Lookupvm.Name,
                            LookupCategoryID = Lookupvm.LookupCategoryID,
                            ParentID = Lookupvm.ServiceQuotaID,
                            IsActive = Lookupvm.IsActive,
                            CreatedBy = UserID,
                            CreatedOn = DateTime.Now
                        };
                        LookupService.AddLookup(Lookup);
                        resposeObj.LookupId = Lookup.ID;
                        resposeObj.status = "successfully";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                    else
                    {
                        resposeObj.status = "Failure";
                        resposeObj.error = "LookupName is already exist";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                }
                else
                {
                    var Check = LookupService.SearchFor(a => a.LookupCategoryID == Lookupvm.LookupCategoryID && a.Name == Lookupvm.Name).FirstOrDefault();
                    if (Check == null)
                    {
                        var Lookup = new Lookup
                        {
                            Name = Lookupvm.Name,
                            LookupCategoryID = Lookupvm.LookupCategoryID,
                            IsActive = Lookupvm.IsActive,
                            CreatedBy = UserID,
                            CreatedOn = DateTime.Now
                        };
                        LookupService.AddLookup(Lookup);
                        resposeObj.LookupId = Lookup.ID;
                        resposeObj.status = "successfully";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                    else
                    {
                        resposeObj.status = "Failure";
                        resposeObj.error = "LookupName is already exist";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                }
                
            }
            catch (Exception ex)
            {
                resposeObj.status = "Failure";
                resposeObj.error = ex.Message;
                ResponseMessage = request.CreateResponse(HttpStatusCode.BadRequest, resposeObj);
            }
            return ResponseMessage;
        }
        [HttpGet]
        [ResponseType(typeof(LookupDetailsResponseObj))]
        public HttpResponseMessage EditLookup(HttpRequestMessage request, int LookupID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new LookupDetailsResponseObj();
            try
            {
                var Lookup = LookupService.GetLookupById(LookupID);
                var LVM = LookupMapping(Lookup);
                resposeObj.Lookup = LVM;
                resposeObj.status = "successfully";
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

        [HttpPut]
        [ResponseType(typeof(AddLookupResponseObj))]
        public HttpResponseMessage EditLookup(HttpRequestMessage request, LookupViewmodel Lookupvm, int LookupID, int UserID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddLookupResponseObj();
            try
            {
                if (Lookupvm.LookupCategoryID == (int)LookupCategories.ServiceQuota)
                {
                    var Check = LookupService.SearchFor(a => a.LookupCategoryID == Lookupvm.LookupCategoryID && a.ParentID == Lookupvm.ServiceProviderID && a.Name == Lookupvm.Name).FirstOrDefault();
                    if (Check == null)
                    {
                        var Lookup = new Lookup
                        {
                            ID= LookupID,
                            Name = Lookupvm.Name,
                            LookupCategoryID = Lookupvm.LookupCategoryID,
                            ParentID = Lookupvm.ServiceProviderID,
                            IsActive = Lookupvm.IsActive,
                            ModifiedBy = UserID,
                            ModifiedOn = DateTime.Now
                        };
                        LookupService.EditLookup(Lookup);
                        resposeObj.LookupId = Lookup.ID;
                        resposeObj.status = "successfully";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                    else
                    {
                        resposeObj.status = "Failure";
                        resposeObj.error = "LookupName is already exist";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                }
                else if (Lookupvm.LookupCategoryID == (int)LookupCategories.Offer)
                {
                    var Check = LookupService.SearchFor(a => a.LookupCategoryID == Lookupvm.LookupCategoryID && a.ParentID == Lookupvm.ServiceQuotaID && a.Name == Lookupvm.Name).FirstOrDefault();
                    if (Check == null)
                    {
                        var Lookup = new Lookup
                        {
                            ID = LookupID,
                            Name = Lookupvm.Name,
                            LookupCategoryID = Lookupvm.LookupCategoryID,
                            ParentID = Lookupvm.ServiceQuotaID,
                            IsActive = Lookupvm.IsActive,
                            ModifiedBy = UserID,
                            ModifiedOn = DateTime.Now
                        };
                        LookupService.EditLookup(Lookup);
                        resposeObj.LookupId = Lookup.ID;
                        resposeObj.status = "successfully";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                    else
                    {
                        resposeObj.status = "Failure";
                        resposeObj.error = "LookupName is already exist";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                }
                else
                {
                    var Check = LookupService.SearchFor(a => a.LookupCategoryID == Lookupvm.LookupCategoryID && a.Name == Lookupvm.Name).FirstOrDefault();
                    if (Check == null)
                    {
                        var Lookup = new Lookup
                        {
                            ID = LookupID,
                            Name = Lookupvm.Name,
                            LookupCategoryID = Lookupvm.LookupCategoryID,
                            IsActive = Lookupvm.IsActive,
                            ModifiedBy = UserID,
                            ModifiedOn = DateTime.Now
                        };
                        LookupService.EditLookup(Lookup);
                        resposeObj.LookupId = Lookup.ID;
                        resposeObj.status = "successfully";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                    else
                    {
                        resposeObj.status = "Failure";
                        resposeObj.error = "LookupName is already exist";
                        ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                    }
                }

            }
            catch (Exception ex)
            {
                resposeObj.status = "Failure";
                resposeObj.error = ex.Message;
                ResponseMessage = request.CreateResponse(HttpStatusCode.BadRequest, resposeObj);
            }
            return ResponseMessage;
        }

        [HttpPut]
        [ResponseType(typeof(AddLookupResponseObj))]
        public HttpResponseMessage EditLookupStatus(HttpRequestMessage request, int LookupID, int UserID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddLookupResponseObj();
            try
            {
                var L = LookupService.GetLookupById(LookupID);
                L.IsActive = (L.IsActive ? false : true);
                L.ModifiedBy = UserID;
                L.ModifiedOn = DateTime.Now;
                LookupService.EditLookup(L);
                resposeObj.status = "successfully";
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

        [HttpGet]
        [ResponseType(typeof(LookupListResponseObj))]
        public HttpResponseMessage LookupList(HttpRequestMessage request, int Page, int PageLimit)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new LookupListResponseObj();
            List<LookupViewmodel> Lookupslist = new List<LookupViewmodel>();
            try
            {
                int Count = LookupService.GetLookupCount();
                var Lookups = LookupService.GetLookupBySQLStatment("select * from [LK].[Lookups] as c order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                if (Lookups.Count > 0)
                {
                    Lookups.ForEach(c =>
                    {
                        var LVM = LookupMapping(c);
                        Lookupslist.Add(LVM);

                    });
                }

                resposeObj.Lookups = Lookupslist;
                resposeObj.TotalCount = Count;
                resposeObj.status = "successfully";
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

        [HttpGet]
        [ResponseType(typeof(LookupListResponseObj))]
        public HttpResponseMessage LookupList(HttpRequestMessage request, int Page, int PageLimit, string SearchText)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new LookupListResponseObj();
            List<LookupViewmodel> Lookupslist = new List<LookupViewmodel>();
            try
            {
                var Lookups = LookupService.GetLookupBySQLStatment("select * from [LK].[Lookups] as c where c.Name=" + SearchText, new object[] { });
                if (Lookups.Count > 0)
                {
                    Lookups.ForEach(c =>
                    {
                        var LVM = LookupMapping(c);
                        Lookupslist.Add(LVM);

                    });
                }

                resposeObj.Lookups = Lookupslist;
                resposeObj.TotalCount = Lookups.Count;
                resposeObj.status = "successfully";
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

        [HttpGet]
        [ResponseType(typeof(LookupListResponseObj))]
        public HttpResponseMessage LookupList(HttpRequestMessage request, int Page, int PageLimit, int CategoryID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new LookupListResponseObj();
            List<LookupViewmodel> Lookupslist = new List<LookupViewmodel>();
            try
            {
                var Lookups = LookupService.GetLookupBySQLStatment("select * from [LK].[Lookups] as c where c.LookupCategoryID=" + CategoryID, new object[] { });
                if (Lookups.Count > 0)
                {
                    Lookups.ForEach(c =>
                    {
                        var LVM = LookupMapping(c);
                        Lookupslist.Add(LVM);

                    });
                }

                resposeObj.Lookups = Lookupslist;
                resposeObj.TotalCount = Lookups.Count;
                resposeObj.status = "successfully";
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
        [HttpGet]
        [ResponseType(typeof(LookupResponseObj))]
        public HttpResponseMessage GetServiceProvider(HttpRequestMessage request)
        {
            var Query = "select * from [LK].[Lookups] as l where l.LookupCategoryID=" + (int)LookupCategories.ServiceProvider;
            return Lookups(request, Query);
        }
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
        [HttpGet]
        [ResponseType(typeof(LookupResponseObj))]
        public HttpResponseMessage GetUserLookups(HttpRequestMessage request)
        {
            var Query = "select * from [LK].[Lookups] as l where l.LookupCategoryID=" + (int)LookupCategories.UserRole;
            return Lookups(request, Query);
        }

        [HttpGet]
        [ResponseType(typeof(LookupCategoryResponseObj))]
        public HttpResponseMessage GetLookupCategory(HttpRequestMessage request)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new LookupCategoryResponseObj();
            try
            {
                var Query = "select * from [LK].[LookupCategory] as c where c.IsManaged='true'";
                var Categories = LookupCategoryService.GetLookupCategoryBySQLStatment(Query, new object[] { });
                var list = MappingLookupCategoryList(Categories);
                resposeObj.status = "successfully";
                resposeObj.Categories = list;
                ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
            }
            catch(Exception ex)
            {
                resposeObj.status = "Failure";
                resposeObj.error = ex.Message;
                ResponseMessage = request.CreateResponse(HttpStatusCode.BadRequest, resposeObj);
            }

            return ResponseMessage;
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
                var UserRoleLst = Lookups.Where(c => c.LookupCategoryID == (int)LookupCategories.UserRole).ToList();

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
                    AccountType= MappingLookupList(AccountTypeLst),
                    UserRole= MappingLookupList(UserRoleLst)
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

        public List<LookupObj> MappingLookupCategoryList(List<LookupCategory> Lookups)
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

        public Lookup LookupVMMapping(LookupViewmodel Lookupvm)
        {
            Lookup L = new Lookup
            {
                IsActive= Lookupvm.IsActive,
                LookupCategoryID=Lookupvm.LookupCategoryID,
                Name=Lookupvm.Name,
                ParentID=Lookupvm.ParentID
            };
            return L;
        }

        public LookupViewmodel LookupMapping(Lookup L)
        {
            LookupViewmodel LVM = new LookupViewmodel()
            {
                CreatedBy = L.CreatedBy,
                CreatedByName = UserService.GetUserName(L.CreatedBy),
                CreatedOn = L.CreatedOn.ToStrDate(),
                IsActive = L.IsActive,
                ModifiedByName = UserService.GetUserName(L.ModifiedBy),
                ModifiedBy = L.ModifiedBy,
                ModifiedOn = L.ModifiedOn.ToStrDate(),
                Name = L.Name,
                ID = L.ID,
                LookupCategoryName = LookupCategoryService.GetCategoryName(L.LookupCategoryID),
                LookupCategoryID=L.LookupCategoryID,
                ParentName=LookupService.GetLookupName(L.ParentID),
                ParentID=L.ParentID,
                ServiceProviderID=(L.LookupCategoryID==(int)LookupCategories.ServiceQuota? L.ParentID:(L.LookupCategoryID == (int)LookupCategories.Offer? GetServiceProviderID(L.ParentID.Value):null)),
                ServiceQuotaID=(L.LookupCategoryID == (int)LookupCategories.Offer ? L.ParentID :null),
            };
            LVM.ServiceProviderName = (LVM.ServiceProviderID != null ? LookupService.GetLookupName(LVM.ServiceProviderID) : string.Empty);
            LVM.ServiceQuotaName = (LVM.ServiceQuotaID != null ? LookupService.GetLookupName(LVM.ServiceQuotaID) : string.Empty);
            return LVM;
        }

        public int? GetServiceProviderID(int ServiceQuotaID)
        {
            var ServiceQuota = LookupService.GetLookupById(ServiceQuotaID);
            return ServiceQuota.ParentID;
        }

    }
}
