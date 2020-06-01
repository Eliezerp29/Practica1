using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalTest.Classes
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext() 
        {
        }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> context) : base(context)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Correos> Correos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NCA9IOO\\SQLEXPRESS01;Initial Catalog=FinalDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

    }

}
