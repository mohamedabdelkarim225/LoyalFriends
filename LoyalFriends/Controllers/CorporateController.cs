using Inno.Core.Data;
using Inno.Utility;
using LoyalFriends.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace LoyalFriends.Controllers
{
    public class CorporateController : ApiBaseController
    {
        [HttpPost]
        [ResponseType(typeof(AddCorporateResponseObj))]
        public HttpResponseMessage AddCorporate(HttpRequestMessage request, CorporateViewModel CorporateVM, int UserID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddCorporateResponseObj();
            try
            {
                var Cor = CorporateVMMapping(CorporateVM);
                Cor.CreatedBy = UserID;
                Cor.CreatedOn = DateTime.Now.Date;
                CorporateService.AddCorporate(Cor);
                //if (!string.IsNullOrEmpty(Cor.Comment))
                //{
                //    AddCorporateCommentsHistory(Cor.ID, UserID, Cor.Comment);
                //}
                resposeObj.CorporateId = Cor.ID;
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
        [ResponseType(typeof(CorporateDetailsResponseObj))]
        public HttpResponseMessage EditCorporate(HttpRequestMessage request, int CorporateID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CorporateDetailsResponseObj();
            try
            {
                var Corporate = CorporateService.GetCorporateById(CorporateID);
                var CorVM = CorporateMapping(Corporate);
                resposeObj.Corporate = CorVM;
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
        [ResponseType(typeof(AddCorporateResponseObj))]
        public HttpResponseMessage EditCorporate(HttpRequestMessage request, CorporateViewModel CorporateVM, int UserID, int CorporateID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddCorporateResponseObj();
            try
            {
                var Cor = CorporateVMMapping(CorporateVM);
                Cor.ID = CorporateID;
                Cor.ModifiedBy = UserID;
                Cor.ModifiedOn = DateTime.Now.Date;
                CorporateService.EditCorporate(Cor);
                //var History = CorporateCommentsHistoryService.GetLastCorporateCommentsHistoryByCorporateId(Cor.ID);
                //if (History != null)
                //{
                //    if (Cor.Comment != History.Comment &&!string.IsNullOrEmpty(Cor.Comment))
                //    {
                //        AddCorporateCommentsHistory(Cor.ID, UserID, Cor.Comment);
                //    }

                //}
                //else
                //{
                //    if (!string.IsNullOrEmpty(Cor.Comment))
                //    {
                //        AddCorporateCommentsHistory(Cor.ID, UserID, Cor.Comment);
                //    }
                //}
                resposeObj.CorporateId = Cor.ID;
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
        [ResponseType(typeof(CorporateDetailsResponseObj))]
        public HttpResponseMessage CorporateDetails(HttpRequestMessage request, int CorporateID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CorporateDetailsResponseObj();
            try
            {
                var Corporate = CorporateService.GetCorporateById(CorporateID);
                var CorVM = CorporateMapping(Corporate);
                var CommentsHistoryLst = CorporateCommentsHistoryService.SearchFor(a => a.CorporateID == CorporateID && a.Comment != null && a.Comment != string.Empty).ToList();
                List<CorporateCommentsHistoryviewModel> CorporateCommentsHistoryviewModelLst = new List<CorporateCommentsHistoryviewModel>();
                if (CommentsHistoryLst.Count > 0)
                {
                    CommentsHistoryLst.ForEach(a =>
                    {
                        CorporateCommentsHistoryviewModelLst.Add(CorporateCommentsHistoryMapping(a));
                    });
                }
                var StatusHistoryLst = CorporateStatusHistoryService.SearchFor(a => a.CorporateID == CorporateID && a.CustomerStatusID != null).ToList();
                List<CorporateStatusHistoryviewModel> CorporateStatusHistoryviewModelLst = new List<CorporateStatusHistoryviewModel>();
                if (StatusHistoryLst.Count > 0)
                {
                    StatusHistoryLst.ForEach(a =>
                    {
                        CorporateStatusHistoryviewModelLst.Add(CorporateStatusHistoryMapping(a));
                    });
                }
                var RejectedReasonHistoryLst = CorporateRejectedReasonHistoryService.SearchFor(a => a.CorporateID == CorporateID && a.RejectedReason != null&& a.RejectedReason != string.Empty).ToList();
                List<CorporateRejectedReasonHistoryviewModel> CorporateRejectedReasonHistoryviewModelLst = new List<CorporateRejectedReasonHistoryviewModel>();
                if (RejectedReasonHistoryLst.Count > 0)
                {
                    RejectedReasonHistoryLst.ForEach(a =>
                    {
                        CorporateRejectedReasonHistoryviewModelLst.Add(CorporateRejectedReasonHistoryMapping(a));
                    });
                }
                resposeObj.Corporate = CorVM;
                resposeObj.CommentsHistory = CorporateCommentsHistoryviewModelLst;
                resposeObj.StatusHistory = CorporateStatusHistoryviewModelLst;
                resposeObj.RejectedReasonHistory = CorporateRejectedReasonHistoryviewModelLst;
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
        public Corporate CorporateVMMapping(CorporateViewModel CorporateVM)
        {
            Corporate Cor = new Corporate
            {
                Name = CorporateVM.Name,
                AccountTypeID = CorporateVM.AccountTypeID,
                Comment = CorporateVM.Comment,
                CompanyAddress = CorporateVM.CompanyAddress,
                CompanyName = CorporateVM.CompanyName,
                CompanyType = CorporateVM.CompanyType,
                CustomerStatusID = CorporateVM.CustomerStatusID,
                RequestTypeID = CorporateVM.RequestTypeID,
                LinesNumber = CorporateVM.LinesNumber,
                Mobile = CorporateVM.Mobile,
                AccountNumber = CorporateVM.AccountNumber,
                ContactDate = Convert.ToDateTime(CorporateVM.ContactDate),
                RejectedReason=CorporateVM.RejectedReason

            };
            return Cor;
        }

        //public bool AddCorporateCommentsHistory(int CorporateID, int UserID, string Comment)
        //{
        //    CorporateCommentsHistory CCH = new CorporateCommentsHistory
        //    {
        //        CorporateID = CorporateID,
        //        Comment = Comment,
        //        CreatedBy = UserID,
        //        CreatedOn = DateTime.Now
        //    };
        //    return CorporateCommentsHistoryService.AddCorporateCommentsHistory(CCH);
        //}

        public CorporateCommentsHistoryviewModel CorporateCommentsHistoryMapping(CorporateCommentsHistory CommentsHistory)
        {
            var HCVM = new CorporateCommentsHistoryviewModel
            {
                Comment = CommentsHistory.Comment,
                CreatedBy = UserService.GetUserName(CommentsHistory.ActionBy),
                CreatedOn = CommentsHistory.ActionOn.ToStrDateTime()
            };
            return HCVM;
        }
        public CorporateStatusHistoryviewModel CorporateStatusHistoryMapping(CorporateStatusHistory StatusHistory)
        {
            var HSVM = new CorporateStatusHistoryviewModel
            {
                Status = LookupService.GetLookupName(StatusHistory.CustomerStatusID),
                CreatedBy = UserService.GetUserName(StatusHistory.ActionBy),
                CreatedOn = StatusHistory.ActionOn.ToStrDateTime()
            };
            return HSVM;
        }
        public CorporateRejectedReasonHistoryviewModel CorporateRejectedReasonHistoryMapping(CorporateRejectedReasonHistory RejectedReasonHistory)
        {
            var HRVM = new CorporateRejectedReasonHistoryviewModel
            {
                RejectedReason = RejectedReasonHistory.RejectedReason,
                CreatedBy = UserService.GetUserName(RejectedReasonHistory.ActionBy),
                CreatedOn = RejectedReasonHistory.ActionOn.ToStrDateTime()
            };
            return HRVM;
        }
        [HttpGet]
        [ResponseType(typeof(CorporateListResponseObj))]
        public HttpResponseMessage CorporateList(HttpRequestMessage request, int UserID, string UserRole, int Page, int PageLimit)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CorporateListResponseObj();
            List<CorporateViewModel> Corporateslist = new List<CorporateViewModel>();
            try
            {
                int Count = 0;
                var Corporates = new List<Corporate>();
                if (UserRole == Roles.Employee.ToString())
                {
                    Count = CorporateService.GetCorporateCount(a => a.CreatedBy == UserID);
                    Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c where c.CreatedBy=" + UserID + "  order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });

                    if (Corporates.Count > 0)
                    {
                        Corporates.ForEach(c =>
                        {
                            var CVM = CorporateMapping(c);
                            Corporateslist.Add(CVM);

                        });
                    }

                }
                else
                {
                    Count = CorporateService.GetCorporateCount();
                    Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    if (Corporates.Count > 0)
                    {
                        Corporates.ForEach(c =>
                        {
                            var CVM = CorporateMapping(c);
                            Corporateslist.Add(CVM);

                        });
                    }
                }
                resposeObj.Corporates = Corporateslist;
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
        [ResponseType(typeof(CorporateListResponseObj))]
        public HttpResponseMessage CorporateList(HttpRequestMessage request, int UserID, string UserRole, int Page, int PageLimit, string SearchText)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CorporateListResponseObj();
            List<CorporateViewModel> Corporateslist = new List<CorporateViewModel>();
            try
            {
                int Count = 0;
                var Corporates = new List<Corporate>();
                if (UserRole == Roles.Employee.ToString())
                {
                    if (string.IsNullOrEmpty(SearchText))
                    {
                        Count = CorporateService.GetCorporateCount(a => a.CreatedBy == UserID);
                        Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c where c.CreatedBy=" + UserID + "  order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    }
                    else
                    {
                        Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c where c.CreatedBy=" + UserID + "and c.Mobile=" + SearchText + "or c.AccountNumber=" + SearchText, new object[] { });
                        Count = Corporates.Count;
                    }
                    if (Corporates.Count > 0)
                    {
                        Corporates.ForEach(c =>
                        {
                            var CVM = CorporateMapping(c);
                            Corporateslist.Add(CVM);

                        });
                    }

                }
                else
                {
                    if (string.IsNullOrEmpty(SearchText))
                    {
                        Count = CorporateService.GetCorporateCount();
                        Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    }
                    else
                    {
                        Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c where c.Mobile=" + SearchText + "or c.AccountNumber=" + SearchText, new object[] { });
                        Count = Corporates.Count;
                    }

                    if (Corporates.Count > 0)
                    {
                        Corporates.ForEach(c =>
                        {
                            var CVM = CorporateMapping(c);
                            Corporateslist.Add(CVM);

                        });
                    }
                }
                resposeObj.Corporates = Corporateslist;
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
        [ResponseType(typeof(CorporateListResponseObj))]
        public HttpResponseMessage CorporateList(HttpRequestMessage request, int UserID, string UserRole, int Page, int PageLimit, int CustomerStatusID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new CorporateListResponseObj();
            List<CorporateViewModel> Corporateslist = new List<CorporateViewModel>();
            try
            {
                int Count = 0;
                var Corporates = new List<Corporate>();
                if (UserRole == Roles.Employee.ToString())
                {
                    if (CustomerStatusID == 0)
                    {
                        Count = CorporateService.GetCorporateCount(a => a.CreatedBy == UserID);
                        Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c where c.CreatedBy=" + UserID + "  order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    }
                    else
                    {
                        Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c where c.CreatedBy=" + UserID + "and c.CustomerStatusID=" + CustomerStatusID, new object[] { });
                        Count = Corporates.Count;
                    }
                    if (Corporates.Count > 0)
                    {
                        Corporates.ForEach(c =>
                        {
                            var CVM = CorporateMapping(c);
                            Corporateslist.Add(CVM);

                        });
                    }

                }
                else
                {
                    if (CustomerStatusID == 0)
                    {
                        Count = CorporateService.GetCorporateCount();
                        Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                    }
                    else
                    {
                        Corporates = CorporateService.GetCorporateBySQLStatment("select * from [dbo].[Corporate]as c where and c.CustomerStatusID=" + CustomerStatusID, new object[] { });
                        Count = Corporates.Count;
                    }

                    if (Corporates.Count > 0)
                    {
                        Corporates.ForEach(c =>
                        {
                            var CVM = CorporateMapping(c);
                            Corporateslist.Add(CVM);

                        });
                    }
                }
                resposeObj.Corporates = Corporateslist;
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

        public CorporateViewModel CorporateMapping(Corporate C)
        {
            CorporateViewModel CVM = new CorporateViewModel()
            {
                Comment = C.Comment,
                CreatedBy = C.CreatedBy,
                CreatedByName = UserService.GetUserName(C.CreatedBy),
                CreatedOn = C.CreatedOn.ToStrDate(),
                CustomerStatus = LookupService.GetLookupName(C.CustomerStatusID),
                CustomerStatusID = C.CustomerStatusID,
                RequestType = LookupService.GetLookupName(C.RequestTypeID),
                RequestTypeID = C.RequestTypeID,
                Mobile = C.Mobile,
                ModifiedBy = C.ModifiedBy,
                ModifiedOn = C.ModifiedOn.ToStrDate(),
                ModifiedByName = UserService.GetUserName(C.ModifiedBy),
                ID = C.ID,
                Name = C.Name,
                AccountNumber = C.AccountNumber,
                AccountType = LookupService.GetLookupName(C.AccountTypeID),
                AccountTypeID = C.AccountTypeID,
                CompanyAddress = C.CompanyAddress,
                CompanyName = C.CompanyName,
                CompanyType = C.CompanyType,
                LinesNumber = C.LinesNumber,
                ContactDate = C.ContactDate.ToStrDate(),
                RejectedReason=C.RejectedReason
            };
            return CVM;
        }


    }
}
