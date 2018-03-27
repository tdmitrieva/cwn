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
                    Currency = ConvertCurruncy(f.Currency)
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
                    Currency = currencyService.GetById(financeToAdd.Finance.Currency.Id),
                    Date = financeToAdd.Finance.Date
                };
                Finance resultFinance = financeService.AddFinance(financeToAdd.Email, financeModel);
                FinanceVm resultFinanceVm = new FinanceVm
                {
                    Id = resultFinance.Id,
                    Amount = resultFinance.Amount,
                    Date = resultFinance.Date,
                    Currency = ConvertCurruncy(resultFinance.Currency)
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultFinanceVm);
            }
            catch (ArgumentException)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        private CurrencyVm ConvertCurruncy(Currency currency)
        {
            CurrencyVm resultCurrency = null;
            if(currency != null)
            {
                resultCurrency = new CurrencyVm
                {
                    Id = currency.Id,
                    Name = currency.Name,
                    Symbol = currency.Symbol
                };
            }
            return resultCurrency;
        }

        public HttpResponseMessage Delete(int id)
        {
            financeService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
