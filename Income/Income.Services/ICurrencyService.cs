using Income.Models;
using System.Collections.Generic;

namespace Income.Services
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetAll();
        Currency GetById(int id);
    }
}
