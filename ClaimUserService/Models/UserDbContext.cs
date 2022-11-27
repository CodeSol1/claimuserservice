using Microsoft.EntityFrameworkCore;

namespace ClaimUserService.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> option): base(option)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
