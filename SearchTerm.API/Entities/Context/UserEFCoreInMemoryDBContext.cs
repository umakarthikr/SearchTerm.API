using Microsoft.EntityFrameworkCore;
namespace SearchTerm.API.Entities.Context
{
    public class UserEFCoreInMemoryDBContext : DbContext
    {
        public UserEFCoreInMemoryDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("UserDB");
        }

        public DbSet<User> Users { get; set; }
    }
}
