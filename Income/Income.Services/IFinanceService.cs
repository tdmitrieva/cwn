using Income.Models;
using System.Collections.Generic;

namespace Income.Services
{
    public interface IFinanceService
    {
        IEnumerable<Finance> GetFinanceByUserEmail(string email);
    }
}
