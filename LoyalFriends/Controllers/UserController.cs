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
    public class UserController : ApiBaseController
    {
        [HttpPost]
        [ResponseType(typeof(UserLoginResponseObj))]
        public HttpResponseMessage Login(HttpRequestMessage request, UserViewModel Uservm)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new UserLoginResponseObj();
            try
            {
                var Check = UserService.CheckUser(Uservm.UserName, Uservm.Password);
                UserObj usr = null;
                if (Check != null)
                {
                    usr = new UserObj
                    {
                        ID = Check.ID,
                        Name = Check.Name,
                        Role = LookupService.GetLookupName(Check.UserRoleID)
                    };
                    resposeObj.User = usr;
                    resposeObj.status = "successfully";
                    ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                }
                else
                {
                    resposeObj.status = "Failure";
                    resposeObj.error = "User Name or Password is invalid";
                    ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
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

        [HttpPost]
        [ResponseType(typeof(AddUserResponseObj))]
        public HttpResponseMessage AddUser(HttpRequestMessage request, UserViewModel Uservm, int UserID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddUserResponseObj();
            try
            {
                if (UserService.IsFound(Uservm.UserName))
                {
                    resposeObj.status = "Failure";
                    resposeObj.error = "Username is already exist";
                    ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                }
                else
                {
                    var Usr = UserVMMapping(Uservm);
                    Usr.CreatedBy = UserID;
                    Usr.CreatedOn = DateTime.Now.Date;
                    UserService.AddUser(Usr);
                    resposeObj.UserId = Usr.ID;
                    resposeObj.status = "successfully";
                    ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);

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
        [ResponseType(typeof(AddUserResponseObj))]
        public HttpResponseMessage EditUserStatus(HttpRequestMessage request, int UID, int UserID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddUserResponseObj();
            try
            {
                var U = UserService.GetUserById(UID);
                U.IsActive = (U.IsActive ? false : true);
                U.ModifiedBy = UserID;
                U.ModifiedOn = DateTime.Now;
                UserService.EditUser(U);
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
        [ResponseType(typeof(UserDetailsResponseObj))]
        public HttpResponseMessage EditUser(HttpRequestMessage request, int UID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new UserDetailsResponseObj();
            try
            {
                var Usr = UserService.GetUserById(UID);
                var UVM = UserMapping(Usr);
                resposeObj.User = UVM;
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
        [ResponseType(typeof(AddUserResponseObj))]
        public HttpResponseMessage EditUser(HttpRequestMessage request, UserViewModel UserVM, int UID, int UserID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new AddUserResponseObj();
            try
            {
                var User = UserService.GetUserById(UID);
                if (UserVM.UserName != User.UserName && UserService.IsFound(UserVM.UserName))
                {
                    resposeObj.status = "Failure";
                    resposeObj.error = "Username is already exist";
                    ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
                }
                else
                {
                    var U = UserVMMapping(UserVM);
                    U.ID = UID;
                    U.ModifiedBy = UserID;
                    U.ModifiedOn = DateTime.Now.Date;
                    UserService.EditUser(U);

                    resposeObj.UserId = U.ID;
                    resposeObj.status = "successfully";
                    ResponseMessage = request.CreateResponse(HttpStatusCode.OK, resposeObj);
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
        [ResponseType(typeof(UserDetailsResponseObj))]
        public HttpResponseMessage UserDetails(HttpRequestMessage request, int UID)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new UserDetailsResponseObj();
            try
            {
                var Usr = UserService.GetUserById(UID);
                var UVM = UserMapping(Usr);
                resposeObj.User = UVM;
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
        [ResponseType(typeof(UserListResponseObj))]
        public HttpResponseMessage UserList(HttpRequestMessage request, int Page, int PageLimit)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new UserListResponseObj();
            List<UserViewModel> Userslist = new List<UserViewModel>();
            try
            {
                int Count = UserService.GetUserCount();
                var Users = UserService.GetUserBySQLStatment("select * from [dbo].[Users]as c order by c.ID desc OFFSET " + (Page - 1) * PageLimit + " ROWS FETCH NEXT " + PageLimit + " ROWS ONLY", new object[] { });
                if (Users.Count > 0)
                {
                    Users.ForEach(c =>
                        {
                            var UVM = UserMapping(c);
                            Userslist.Add(UVM);

                        });
                }

                resposeObj.Users = Userslist;
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
        [ResponseType(typeof(UserListResponseObj))]
        public HttpResponseMessage UserList(HttpRequestMessage request, int Page, int PageLimit, string SearchText)
        {
            var ResponseMessage = new HttpResponseMessage();
            var resposeObj = new UserListResponseObj();
            List<UserViewModel> Userslist = new List<UserViewModel>();
            try
            {
                var Users = UserService.GetUserBySQLStatment("select * from [dbo].[Users]as c where c.Mobile=" + SearchText, new object[] { });
                if (Users.Count > 0)
                {
                    Users.ForEach(c =>
                    {
                        var UVM = UserMapping(c);
                        Userslist.Add(UVM);

                    });
                }

                resposeObj.Users = Userslist;
                resposeObj.TotalCount = Users.Count;
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
        public User UserVMMapping(UserViewModel Uservm)
        {
            User Usr = new User
            {
                Email = Uservm.Email,
                IsActive = Uservm.IsActive,
                Mobile = Uservm.Mobile,
                Name = Uservm.Name,
                Password = Uservm.Password,
                UserName = Uservm.UserName,
                UserRoleID = Uservm.UserRoleID,

            };
            return Usr;
        }

        public UserViewModel UserMapping(User U)
        {
            UserViewModel UVM = new UserViewModel()
            {
                CreatedBy = U.CreatedBy,
                CreatedByName = UserService.GetUserName(U.CreatedBy),
                CreatedOn = U.CreatedOn.ToStrDate(),
                Email = U.Email,
                IsActive = U.IsActive,
                Mobile = U.Mobile,
                ModifiedByName = UserService.GetUserName(U.ModifiedBy),
                ModifiedBy = U.ModifiedBy,
                ModifiedOn = U.ModifiedOn.ToStrDate(),
                Name = U.Name,
                ID = U.ID,
                Password = U.Password,
                UserName = U.UserName,
                UserRole = LookupService.GetLookupName(U.UserRoleID),
                UserRoleID = U.UserRoleID
            };
            return UVM;
        }

    }
}
