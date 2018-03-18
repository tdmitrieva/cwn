using Income.Models;

namespace Income.Services
{
    public interface IUserServise
    {
        User GetByEmail(string email);
    }
}
