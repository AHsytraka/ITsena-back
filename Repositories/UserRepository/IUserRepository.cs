using ITsena_back.Models;

namespace ITsena_back.Repositories;

public interface IUserRepository
{
    public Task<User> SignupUser(User user);
    public User GetUserByEmail(string email);
}