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

        public IEnumerable<Finance> GetFinanceByUserEmail(string email)
        {
            Repository<User> userRepository = unitOfWork.GetRepository<User>();
            User user = userRepository.Query().FirstOrDefault(u => string.Compare(u.Email, email, true) == 0);
            if(user == null)
            {
                throw new ArgumentException("User does't exist");
            }
            return user.Finances;
        }
    }
}
