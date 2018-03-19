using Income.Models;
using Income.Services;
using Income.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Income.Web.Controllers
{
    public class FinancesController : ApiController
    {
        private IFinanceService financeService;
        public FinancesController(IFinanceService financeService)
        {
            this.financeService = financeService;
        }

        public HttpResponseMessage Get(string email)
        {
            try
            {
                List<Finance> finances = financeService.GetFinanceByUserEmail(email).ToList();
                IEnumerable<FinanceVm> financesVm = finances.Select(f => new FinanceVm
                {
                    Id = f.Id,
                    Amount = f.Amount,
                    Date = f.Date,
                    Currency = f.Currency.Symbol
                });
                return Request.CreateResponse(HttpStatusCode.OK, financesVm); ;
            }
            catch (ArgumentException)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Enumerable.Empty<FinanceVm>());
            }
        }
    }
}
