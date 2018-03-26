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
        private ICurrencyService currencyService;
        public FinancesController(IFinanceService financeService, ICurrencyService currencyService)
        {
            this.financeService = financeService;
            this.currencyService = currencyService;
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
                    CurrencyId = f.Currency.Id
                });
                return Request.CreateResponse(HttpStatusCode.OK, financesVm); ;
            }
            catch (ArgumentException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Enumerable.Empty<FinanceVm>());
            }
        }

        public HttpResponseMessage Post(FinancePostVm financeToAdd)
        {
            try
            {
                Finance financeModel = new Finance
                {
                    Amount = financeToAdd.Finance.Amount,
                    Currency = currencyService.GetById(financeToAdd.Finance.CurrencyId),
                    Date = financeToAdd.Finance.Date
                };
                financeService.AddFinance(financeToAdd.Email, financeModel);
            }
            catch (ArgumentException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
