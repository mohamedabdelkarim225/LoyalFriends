using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace testApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : ApiController
    {
        [HttpPost, HttpGet]
        public HttpResponseMessage add(HttpRequestMessage request)
        {
            var ResponseMessage = new HttpResponseMessage();
            
            try
            {
                
                ResponseMessage = request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                
                ResponseMessage = request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return ResponseMessage;
        }


    }
}
