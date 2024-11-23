using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace emp_system.Models
{
    public class appcontext : IdentityDbContext<appuser>
    {
        public DbSet<doctor> doctors {  get; set; }
        public DbSet<patient> patients {  get; set; } 
        public DbSet< specialty> specialties { get; set; }
        public DbSet<appointment> appointments { get; set; }
        
        public appcontext(DbContextOptions<appcontext> options):base(options) { }
        public appcontext() : base() { }
         
    }
}
