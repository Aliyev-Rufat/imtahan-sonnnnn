using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication15.Models;

namespace WebApplication15.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options): base(options) { }

       public DbSet<Team> Teams { get; set; }   
    }
}
