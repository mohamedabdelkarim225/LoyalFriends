using Inno.Core.Data;
using LoyalFriends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Inno.Utility;
namespace LoyalFriends.Controllers
{
    public class CustomerController : ApiBaseController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [ResponseType(typeof(AddCustomerResponseObj))]
        public HttpResponseMessage AddCustomer(HttpRequestMessage request, CustomerViewModel customerVM, int UserID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddCustomerResponseObj();
            try
            {
                var Cust = CustomerVMMapping(customerVM);
                Cust.CreatedBy = UserID;
                Cust.CreatedOn = DateTime.Now.Date;
                CustomerService.AddCustomer(Cust);
                if (!string.IsNullOrEmpty(Cust.Comment))
                {
                    AddCustomerCommentsHistory(Cust.ID, UserID, Cust.Comment);
                }
                resposeObj.CustomerId = Cust.ID;
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
        [ResponseType(typeof(CustomerDetailsResponseObj))]
        public HttpResponseMessage EditCustomer(HttpRequestMessage request, int CustomerID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CustomerDetailsResponseObj();
            try
            {
                var Customer = CustomerService.GetCustomerById(CustomerID);
                var CustVM = CustomerMapping(Customer);
                resposeObj.Customer = CustVM;
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
        [ResponseType(typeof(AddCustomerResponseObj))]
        public HttpResponseMessage EditCustomer(HttpRequestMessage request, CustomerViewModel customerVM, int UserID, int CustomerID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddCustomerResponseObj();
            try
            {
                var Cust = CustomerVMMapping(customerVM);
                Cust.ID = CustomerID;
                Cust.ModifiedBy = UserID;
                Cust.ModifiedOn = DateTime.Now.Date;
                CustomerService.EditCustomer(Cust);
                var History = CustomerCommentsHistoryService.GetLastCustomerCommentsHistoryByCustomerId(Cust.ID);
                if (History != null)
                {
                    if (Cust.Comment != History.Comment)
                    {
                        AddCustomerCommentsHistory(Cust.ID, UserID, Cust.Comment);
                    }

                }
                resposeObj.CustomerId = Cust.ID;
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
        [ResponseType(typeof(CustomerDetailsResponseObj))]
        public HttpResponseMessage CustomerDetails(HttpRequestMessage request, int CustomerID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CustomerDetailsResponseObj();
            try
            {
                var Customer = CustomerService.GetCustomerById(CustomerID);
                var CustVM = CustomerMapping(Customer);
                var HistoryLst = CustomerCommentsHistoryService.SearchFor(a => a.CustomerID == CustomerID).ToList();
                List<CustomerHistoryviewModel> CustomerHistoryviewModelLst = new List<CustomerHistoryviewModel>();
                if (HistoryLst.Count > 0)
                {
                    HistoryLst.ForEach(a =>
                    {
                        CustomerHistoryviewModelLst.Add(CustomerCommentsHistoryMapping(a));
                    });
                }
                resposeObj.Customer = CustVM;
                resposeObj.History = CustomerHistoryviewModelLst;
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
        public Customer CustomerVMMapping(CustomerViewModel customerVM)
        {
            Customer Cust = new Customer
            {
                Name = customerVM.Name,
                Address = customerVM.Address,
                Central = customerVM.Central,
                City = customerVM.City,
                Comment = customerVM.Comment,
                ContactDate = Convert.ToDateTime(customerVM.ContactDate),
                CustomerStatusID = customerVM.CustomerStatusID,
                RequestTypeID = customerVM.RequestTypeID,
                CustomerTypeID = customerVM.CustomerTypeID,
                District = customerVM.District,
                FixedLine = customerVM.FixedLine,
                GovernorateID = customerVM.GovernorateID,
                Mobile = customerVM.Mobile,
                NationalId = customerVM.NationalId,
                NearestFixedLine = customerVM.NearestFixedLine,
                OfferID = customerVM.OfferID,
                RouterDeliveryMethodID = customerVM.RouterDeliveryMethodID,
                RouterTypeID = customerVM.RouterTypeID,
                ServiceProviderID = customerVM.ServiceProviderID,
                ServiceQuotaID = customerVM.ServiceQuotaID,
                SpecialMark = customerVM.SpecialMark,
                RequestNumber = customerVM.RequestNumber
            };
            return Cust;
        }

        public bool AddCustomerCommentsHistory(int CustomerID, int UserID, string Comment)
        {
            CustomerCommentsHistory CCH = new CustomerCommentsHistory
            {
                CustomerID = CustomerID,
                Comment = Comment,
                CreatedBy = UserID,
                CreatedOn = DateTime.Now
            };
            return CustomerCommentsHistoryService.AddCustomerCommentsHistory(CCH);
        }

        public CustomerHistoryviewModel CustomerCommentsHistoryMapping(CustomerCommentsHistory History)
        {
            var HVM = new CustomerHistoryviewModel
            {
                Comment = History.Comment,
                CreatedBy = UserService.GetUserName(History.CreatedBy),
                CreatedOn = History.CreatedOn.ToStrDateTime()
            };
            return HVM;
        }

        [HttpGet]
        [ResponseType(typeof(CustomerListResponseObj))]
        public HttpResponseMessage CustomerList(HttpRequestMessage request, int UserID, string UserRole, int CustomerType, int Page, int PageLimit)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CustomerListResponseObj();
            List<CustomerViewModel> Customerslist = new List<CustomerViewModel>();
            try
            {
                int Count = 0;
                var Customers = new List<Customer>();
                if (UserRole == Roles.Employee.ToString())
                {
                    Count = CustomerService.GetCustomerCount(a => a.CreatedBy == UserID && a.CustomerTypeID == CustomerType);
                    Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where c.CreatedBy=" + UserID + " and c.CustomerTypeID=" + CustomerType + "  order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });

                    if (Customers.Count > 0)
                    {
                        Customers.ForEach(c =>
                        {
                            var CVM = CustomerMapping(c);
                            Customerslist.Add(CVM);

                        });
                    }

                }
                else
                {
                    Count = CustomerService.GetCustomerCount(a => a.CustomerTypeID == CustomerType);
                    Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where c.CustomerTypeID=" + CustomerType + "  order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    if (Customers.Count > 0)
                    {
                        Customers.ForEach(c =>
                        {
                            var CVM = CustomerMapping(c);
                            Customerslist.Add(CVM);

                        });
                    }
                }
                resposeObj.Customers = Customerslist;
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
        [ResponseType(typeof(CustomerListResponseObj))]
        public HttpResponseMessage CustomerList(HttpRequestMessage request, int UserID, string UserRole, int CustomerType, int Page, int PageLimit, string SearchText)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CustomerListResponseObj();
            List<CustomerViewModel> Customerslist = new List<CustomerViewModel>();
            try
            {
                int Count = 0;
                var Customers = new List<Customer>();
                if (UserRole == Roles.Employee.ToString())
                {
                    if (string.IsNullOrEmpty(SearchText))
                    {
                        Count = CustomerService.GetCustomerCount(a => a.CreatedBy == UserID && a.CustomerTypeID == CustomerType);
                        Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where c.CreatedBy=" + UserID + " and c.CustomerTypeID=" + CustomerType + "  order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    }
                    else
                    {
                        Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where c.CreatedBy=" + UserID + " and c.CustomerTypeID=" + CustomerType + " and c.Mobile=" + SearchText + " or c.RequestNumber=" + SearchText, new object[] { });
                        Count = Customers.Count;
                    }
                    if (Customers.Count > 0)
                    {
                        Customers.ForEach(c =>
                        {
                            var CVM = CustomerMapping(c);
                            Customerslist.Add(CVM);

                        });
                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(SearchText))
                    {
                        Count = CustomerService.GetCustomerCount(a => a.CustomerTypeID == CustomerType);
                        Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where c.CustomerTypeID=" + CustomerType + "  order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    }
                    else
                    {
                        Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where  c.CustomerTypeID=" + CustomerType + " and c.Mobile=" + SearchText+ " or c.RequestNumber="+SearchText, new object[] { });
                        Count = Customers.Count;
                    }

                    if (Customers.Count > 0)
                    {
                        Customers.ForEach(c =>
                        {
                            var CVM = CustomerMapping(c);
                            Customerslist.Add(CVM);

                        });
                    }
                }
                resposeObj.Customers = Customerslist;
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
        [ResponseType(typeof(CustomerListResponseObj))]
        public HttpResponseMessage CustomerList(HttpRequestMessage request, int UserID, string UserRole, int CustomerType, int Page, int PageLimit, int CustomerStatusID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CustomerListResponseObj();
            List<CustomerViewModel> Customerslist = new List<CustomerViewModel>();
            try
            {
                int Count = 0;
                var Customers = new List<Customer>();
                if (UserRole == Roles.Employee.ToString())
                {
                    if (CustomerStatusID == 0)
                    {
                        Count = CustomerService.GetCustomerCount(a => a.CreatedBy == UserID && a.CustomerTypeID == CustomerType);
                        Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where c.CreatedBy=" + UserID + " and c.CustomerTypeID=" + CustomerType + "  order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    }
                    else
                    {
                        Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where c.CreatedBy=" + UserID + " and c.CustomerTypeID=" + CustomerType + "and c.CustomerStatusID=" + CustomerStatusID, new object[] { });
                        Count = Customers.Count;
                    }
                    if (Customers.Count > 0)
                    {
                        Customers.ForEach(c =>
                        {
                            var CVM = CustomerMapping(c);
                            Customerslist.Add(CVM);

                        });
                    }

                }
                else
                {
                    if (CustomerStatusID == 0)
                    {
                        Count = CustomerService.GetCustomerCount(a => a.CustomerTypeID == CustomerType);
                        Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where c.CustomerTypeID=" + CustomerType + "  order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    }
                    else
                    {
                        Customers = CustomerService.GetCustomerBySQLStatment("select * from [dbo].[Customer]as c where  c.CustomerTypeID=" + CustomerType + "and c.CustomerStatusID=" + CustomerStatusID, new object[] { });
                        Count = Customers.Count;
                    }

                    if (Customers.Count > 0)
                    {
                        Customers.ForEach(c =>
                        {
                            var CVM = CustomerMapping(c);
                            Customerslist.Add(CVM);

                        });
                    }
                }
                resposeObj.Customers = Customerslist;
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
        public CustomerViewModel CustomerMapping(Customer C)
        {
            CustomerViewModel CVM = new CustomerViewModel()
            {
                Address = C.Address,
                Central = C.Central,
                City = C.City,
                Comment = C.Comment,
                ContactDate = C.ContactDate.ToStrDate(),
                CreatedBy = C.CreatedBy,
                CreatedByName = UserService.GetUserName(C.CreatedBy),
                CreatedOn = C.CreatedOn.ToStrDate(),
                CustomerStatus = LookupService.GetLookupName(C.CustomerStatusID),
                CustomerStatusID = C.CustomerStatusID,
                RequestType = LookupService.GetLookupName(C.RequestTypeID),
                RequestTypeID = C.RequestTypeID,
                CustomerType = LookupService.GetLookupName(C.CustomerTypeID),
                CustomerTypeID = C.CustomerTypeID,
                District = C.District,
                FixedLine = C.FixedLine,
                Governorate = LookupService.GetLookupName(C.GovernorateID),
                GovernorateID = C.GovernorateID,
                Mobile = C.Mobile,
                ModifiedBy = C.ModifiedBy,
                ModifiedOn = C.ModifiedOn.ToStrDate(),
                ModifiedByName = UserService.GetUserName(C.ModifiedBy),
                ID = C.ID,
                Name = C.Name,
                NationalId = C.NationalId,
                NearestFixedLine = C.NearestFixedLine,
                Offer = LookupService.GetLookupName(C.OfferID),
                OfferID = C.OfferID,
                RouterDeliveryMethod = LookupService.GetLookupName(C.RouterDeliveryMethodID),
                RouterDeliveryMethodID = C.RouterDeliveryMethodID,
                RouterType = LookupService.GetLookupName(C.RouterTypeID),
                RouterTypeID = C.RouterTypeID,
                ServiceProvider = LookupService.GetLookupName(C.ServiceProviderID),
                ServiceProviderID = C.ServiceProviderID,
                ServiceQuota = LookupService.GetLookupName(C.ServiceQuotaID),
                ServiceQuotaID = C.ServiceQuotaID,
                SpecialMark = C.SpecialMark,
                RequestNumber = C.RequestNumber

            };
            return CVM;
        }
    }

}

