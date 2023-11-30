using CV.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CV.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<PersonalInfo> PersonalInfo {get;set;}
        public DbSet<Nationality> Nationality { get; set; }
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public ApplicationDbContext() { }
    }
}
