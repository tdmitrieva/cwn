using System.Collections.Generic;
using Income.Models;
using Income.Repositories;
using System.Linq;
using System;

namespace Income.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork unitOfWork;
        public CurrencyService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<Currency> GetAll()
        {
            return unitOfWork.GetRepository<Currency>().Query().ToList();
        }

        public Currency GetById(int id)
        {
            return unitOfWork.GetRepository<Currency>().GetById(id);
        }
    }
}
