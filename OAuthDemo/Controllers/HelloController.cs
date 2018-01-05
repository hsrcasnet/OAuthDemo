using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OAuthDemo.Controllers
{
    [RoutePrefix("api/hello")]
    public class HelloController : ApiController
    {
        [HttpGet]
        [Route("sayhello")]
        public string SayHello()
        {
            return "hello";
        }
    }
}