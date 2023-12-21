using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class MLSAContext : IdentityDbContext<AppUser,AppRole,int>

    { 
        private readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=mlsaappdemoforidentity;Integrated Security=True";

        public MLSAContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"{ConnectionString}");
        }
        public DbSet<AppUser> AppUsers { get; set; }
        
    }
}