using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class MLSAContext : IdentityDbContext<AppUser,AppRole,int>

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=mlsaappdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            optionsBuilder.UseSqlServer("");

        }

        //public MLSAContext(DbContextOptions<MLSAContext> dbContextOptions):base(dbContextOptions)
        //{
        //}

        public DbSet<AppUser> AppUsers { get; set; }
        
    }
}