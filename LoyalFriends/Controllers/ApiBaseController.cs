using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace LoyalFriends.Controllers
{
   
    public class ApiBaseController : ApiController
    {
        public static Inno.Service.User.User UserService;
        public static Inno.Service.Lookup.Lookup LookupService;
        public static Inno.Service.LookupCategory.LookupCategory LookupCategoryService;
        public static Inno.Service.Customer.Customer CustomerService;
        public static Inno.Service.CustomerCommentsHistory.CustomerCommentsHistory CustomerCommentsHistoryService;
        public static Inno.Service.CustomerStatusHistory.CustomerStatusHistory CustomerStatusHistoryService;
        public static Inno.Service.CustomerRejectedReasonHistory.CustomerRejectedReasonHistory CustomerRejectedReasonHistoryService;
        public static Inno.Service.Corporate.Corporate CorporateService;
        public static Inno.Service.CorporateCommentsHistory.CorporateCommentsHistory CorporateCommentsHistoryService;
        public static Inno.Service.CorporateStatusHistory.CorporateStatusHistory CorporateStatusHistoryService;
        public static Inno.Service.CorporateRejectedReasonHistory.CorporateRejectedReasonHistory CorporateRejectedReasonHistoryService;

        public ApiBaseController()
        {
            UserService = new Inno.Service.User.User();
            LookupService = new Inno.Service.Lookup.Lookup();
            LookupCategoryService = new Inno.Service.LookupCategory.LookupCategory();
            CustomerService = new Inno.Service.Customer.Customer();
            CustomerCommentsHistoryService = new Inno.Service.CustomerCommentsHistory.CustomerCommentsHistory();
            CustomerStatusHistoryService = new Inno.Service.CustomerStatusHistory.CustomerStatusHistory();
            CustomerRejectedReasonHistoryService = new Inno.Service.CustomerRejectedReasonHistory.CustomerRejectedReasonHistory();
            CorporateService = new Inno.Service.Corporate.Corporate();
            CorporateCommentsHistoryService = new Inno.Service.CorporateCommentsHistory.CorporateCommentsHistory();
            CorporateStatusHistoryService = new Inno.Service.CorporateStatusHistory.CorporateStatusHistory();
            CorporateRejectedReasonHistoryService = new Inno.Service.CorporateRejectedReasonHistory.CorporateRejectedReasonHistory();
        }
       
    }
}
