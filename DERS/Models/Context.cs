using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DERS.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"server=DESKTOP-QP5A446;database=Rolleme;Trusted_Connection=true;");
        }
       public DbSet<Admin> Admins { get; set; }
    }
}
