using Income.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Income.Web.Controllers
{
    public class UsersController : ApiController
    {
        IUserServise userService = null;
        public UsersController(IUserServise userService)
        {
            this.userService = userService;
        }

        public HttpResponseMessage Get([FromUri]string email)
        {

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
