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
    public class CurrenciesController : ApiController
    {
        private readonly ICurrencyService currencySerice;
        public CurrenciesController(ICurrencyService currencySerice)
        {
            this.currencySerice = currencySerice;
        }

        public HttpResponseMessage Get()
        {
            List<Currency> currencies = currencySerice.GetAll().ToList();
            IEnumerable<CurrencyVm> currenciesVm = currencies.Select(c => new CurrencyVm
            {
                Id = c.Id,
                Name = c.Name,
                Symbol = c.Symbol
            });
            return Request.CreateResponse(HttpStatusCode.OK, currenciesVm);
        }

    }
}
