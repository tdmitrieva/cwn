using Income.Models;
using Income.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Income.Web.Controllers
{
    public class UsersController : ApiController
    {
        IUserServise userService = null;
        public UsersController(IUserServise userService)
        {
            this.userService = userService;
        }

        [ResponseType(typeof(bool))]
        public HttpResponseMessage Get([FromUri]string email)
        {
            User user = userService.GetByEmail(email);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
