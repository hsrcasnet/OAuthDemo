using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace OAuthDemo.Controllers
{
    [Authorize]
    [RoutePrefix("api/hello")]
    public class HelloController : ApiController
    {
        [HttpGet]
        [Route("sayhello")]
        public string SayHello()
        {
            return $"Hello, {this.User.Identity.Name}";
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("getclaims")]
        public string GetRoles()
        {
            var claimsIdentity = (ClaimsPrincipal)this.User;
            return $"Claims: {string.Join(", ", claimsIdentity.Claims)}";
        }
    }
}