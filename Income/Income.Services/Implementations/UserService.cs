using System;
using Income.Repositories;
using Income.Models;
using System.Linq;

namespace Income.Services.Implementations
{
    public class UserService : IUserServise
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWorkInstance)
        {
            unitOfWork = unitOfWorkInstance;
        }

        public User GetByEmail(string email)
        {
            Repository<User> userRepository = unitOfWork.GetRepository<User>();
            User user = userRepository.Query().FirstOrDefault(u => string.Compare(u.Email, email, true) == 0);
            return user;
        }
    }
}
