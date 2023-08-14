using ITsena_back.Data;
using ITsena_back.Models;

namespace ITsena_back.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;
    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> SignupUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public User GetUserByEmail(string email)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
        return user;
    }

    public User GetUserById(Guid guid)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.UserId == guid);
        return user;
    }
}