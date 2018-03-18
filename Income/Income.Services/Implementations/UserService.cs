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

        public bool IsUserExists(string email)
        {
            Repository<User> userRepository = unitOfWork.GetRepository<User>();
            bool userExists = userRepository.Query().Any(user => string.Compare(user.Email, email, true) == 0);
            return userExists;
        }
    }
}
