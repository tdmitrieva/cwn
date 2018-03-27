using Income.Models;
using System.Collections.Generic;

namespace Income.Services
{
    public interface IFinanceService
    {
        IEnumerable<Finance> GetFinanceByUserEmail(string email);
        Finance AddFinance(string email, Finance finance);
        void Delete(int id);
    }
}
