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
               
            }
            catch(Exception ex)
            {
                resposeObj.status = "Failure";
                resposeObj.error = ex.Message;
                ResponseMessage = request.CreateResponse(HttpStatusCode.BadRequest, resposeObj);
            }

            return ResponseMessage;
        }
    }
}
