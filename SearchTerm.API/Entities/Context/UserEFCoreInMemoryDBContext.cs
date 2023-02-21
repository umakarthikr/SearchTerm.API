using Microsoft.EntityFrameworkCore;
namespace SearchTerm.API.Entities.Context
{
    public class UserEFCoreInMemoryDBContext : DbContext
    {
        public UserEFCoreInMemoryDBContext() { }

        public UserEFCoreInMemoryDBContext(DbContextOptions<UserEFCoreInMemoryDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("UserDB");
        }

        public DbSet<User> Users { get; set; }
    }
}
