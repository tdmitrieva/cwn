using Income.Models;
using Income.Services;
using Income.Web.ViewModels;
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

        public HttpResponseMessage Get([FromUri]string email)
        {
            User user = userService.GetByEmail(email);
            UserVm userVm = user != null ? new UserVm { Email = user.Email } : null;
            return Request.CreateResponse(HttpStatusCode.OK, userVm);
        }
    }
}
