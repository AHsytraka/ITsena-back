using ITsena_back.Models;
using Microsoft.EntityFrameworkCore;

namespace ITsena_back.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
    {
        
    }

    public DbSet<User>Users => Set<User>();
}