using Income.Models;
using Income.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Income.Services.Implementations
{
    public class FinanceService: IFinanceService
    {
        private IUnitOfWork unitOfWork;
        public FinanceService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddFinance(string email, Finance finance)
        {
            User user = GetUser(email);
            Repository<Finance> financeRepository = unitOfWork.GetRepository<Finance>();
            finance.User = user;
            financeRepository.Create(finance);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Finance> GetFinanceByUserEmail(string email)
        {
            User user = GetUser(email);
            Repository<Finance> financeRepository = unitOfWork.GetRepository<Finance>();
            return financeRepository.Query().Where(f => f.User.Id == user.Id);
        }

        private User GetUser(string email)
        {
            Repository<User> userRepository = unitOfWork.GetRepository<User>();
            User user = userRepository.Query().FirstOrDefault(u => string.Compare(u.Email, email, true) == 0);
            if (user == null)
            {
                throw new ArgumentException("User does't exist");
            }
            return user;
        }

    }
}
